using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PetClinicBusinessLogic.Enums;
using PetClinicFileImplement.Models;

namespace PetClinicFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string MedicineFileName = "Medicine.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string VisitFileName = "Visit.xml";
        private readonly string ServiceFileName = "Service.xml";
        private readonly string ServiceMedicineFileName = "ServiceMedicine.xml";
        private readonly string MessageInfoFileName = "MessageInfoFileName.xml";
        public List<Medicine> Medicines { get; set; }
        public List<Client> Clients { get; set; }
        public List<Visit> Visits { get; set; }
        public List<Service> Services { get; set; }
        public List<ServiceMedicine> ServiceMedicines { get; set; }
        public List<MessageInfo> MessageInfos { get; set; }
        private FileDataListSingleton()
        {
            Medicines = LoadMedicines();
            Clients= LoadClients();
            Visits = LoadVisits();
            Services = LoadServices();
            ServiceMedicines = LoadServiceMedicines();
            MessageInfos = LoadMessageInfos();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveMedicines();
            SaveClients();
            SaveVisits();
            SaveServices();
            SaveServiceMedicines();
            SaveMessageInfos();
        }
        private List<Medicine> LoadMedicines()
        {
            var list = new List<Medicine>();
            if (File.Exists(MedicineFileName))
            {
                XDocument xDocument = XDocument.Load(MedicineFileName);
                var xElements = xDocument.Root.Elements("Medicine").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Medicine
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MedicineName = elem.Element("MedicineName").Value
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FIO = elem.Element("FIO").Value,
                        Login = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value,
                        Email=elem.Element("Email").Value,
                        Phone=elem.Element("Phone").Value
                    });
                }
            }
            return list;
        }
        private List<Visit> LoadVisits()
        {
            var list = new List<Visit>();
                if (File.Exists(VisitFileName))
                {
                    XDocument xDocument = XDocument.Load(VisitFileName);
                    var xElements = xDocument.Root.Elements("Visit").ToList();
                    foreach (var elem in xElements)
                    {
                        list.Add(new Visit
                        {
                            Id = Convert.ToInt32(elem.Attribute("Id").Value),
                            ClientId= Convert.ToInt32(elem.Attribute("ClientId").Value),
                            ServiceId = Convert.ToInt32(elem.Element("ServiceId").Value),
                            Animal=elem.Element("Animal").Value,
                            AnimalName=elem.Element("AnimalName").Value,
                            Count = Convert.ToInt32(elem.Element("Count").Value),
                            Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                            Status = (VisitStatus)Enum.Parse(typeof(VisitStatus),elem.Element("Status").Value),
                            DateVisit = Convert.ToDateTime(elem.Element("DateVisit").Value),
                        });
                    }
                }
                return list;
            }
        private List<Service> LoadServices()
        {
            var list = new List<Service>();
            if (File.Exists(ServiceFileName))
            {
                XDocument xDocument = XDocument.Load(ServiceFileName);
                var xElements = xDocument.Root.Elements("Service").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Service
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ServiceName = elem.Element("ServiceName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<ServiceMedicine> LoadServiceMedicines()
        {
            var list = new List<ServiceMedicine>();
            if (File.Exists(ServiceMedicineFileName))
            {
                XDocument xDocument = XDocument.Load(ServiceMedicineFileName);
                var xElements = xDocument.Root.Elements("ServiceMedicine").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new ServiceMedicine
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ServiceId = Convert.ToInt32(elem.Element("ServiceId").Value),
                        MedicineId = Convert.ToInt32(elem.Element("MedicineId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveMedicines()
        {
            if (Medicines != null)
            {
                var xElement = new XElement("Medicines");
                foreach (var medicine in Medicines)
                {
                    xElement.Add(new XElement("Medicine",
                    new XAttribute("Id", medicine.Id),
                    new XElement("MedicineName", medicine.MedicineName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MedicineFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("FIO", client.FIO),
                    new XElement("Email", client.Login),
                    new XElement("Password", client.Password),
                    new XElement("Email", client.Email),
                    new XElement("Phone", client.Phone)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private List<MessageInfo> LoadMessageInfos()
        {
            var list = new List<MessageInfo>();

            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery").Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value
                    });
                }
            }

            return list;
        }
        private void SaveVisits()
        {
            if (Visits != null)
            {
                var xElement = new XElement("Visits");
                foreach (var visit in Visits)
                {
                    xElement.Add(new XElement("Visit",
                    new XAttribute("Id", visit.Id),
                    new XAttribute("ClientId", visit.ClientId),
                    new XElement("ServiceId", visit.ServiceId),
                    new XElement("Animal", visit.Animal),
                    new XElement("AnimalName", visit.AnimalName),
                    new XElement("Count", visit.Count),
                    new XElement("Sum", visit.Sum),
                    new XElement("Status", visit.Status),
                    new XElement("DateVisit", visit.DateVisit)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(VisitFileName);
            }
        }
        private void SaveServices()
        {
            if (Services != null)
            {
                var xElement = new XElement("Services");
                foreach (var service in Services)
                {
                    xElement.Add(new XElement("Ship",
                    new XAttribute("Id", service.Id),
                    new XElement("ServiceName", service.ServiceName),
                    new XElement("Price", service.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ServiceFileName);
            }
        }
        private void SaveServiceMedicines()
        {
            if (ServiceMedicines != null)
            {
                var xElement = new XElement("ServiceMedicines");
                foreach (var serviceMedicine in ServiceMedicines)
                {
                    xElement.Add(new XElement("ServiceMedicine",
                    new XAttribute("Id", serviceMedicine.Id),
                    new XElement("ServiceId", serviceMedicine.ServiceId),
                    new XElement("MedicineId", serviceMedicine.MedicineId),
                    new XElement("Count", serviceMedicine.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ServiceMedicineFileName);
            }
        }
        private void SaveMessageInfos()
        {
            if (MessageInfos != null)
            {
                var xElement = new XElement("MessageInfoes");

                foreach (var messageInfo in MessageInfos)
                {
                    xElement.Add(new XElement("MessageInfo",
                    new XAttribute("Id", messageInfo.MessageId),
                    new XElement("ClientId", messageInfo.ClientId),
                    new XElement("SenderName", messageInfo.SenderName),
                    new XElement("DateDelivery", messageInfo.DateDelivery),
                    new XElement("Subject", messageInfo.Subject),
                    new XElement("Body", messageInfo.Body)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
    }
}
