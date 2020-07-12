using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.HelperModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinicBusinessLogic.BusinessLogics
{
    public class ReportAdminLogic
    {
        private readonly IServiceLogic serviceLogic;
        private readonly IVisitLogic visitLogic;
        private readonly IMedicineLogic medicineLogic;
        
        public ReportAdminLogic(IServiceLogic serviceLogic, IVisitLogic visitLogic, IMedicineLogic medicineLogic)
        {
            this.serviceLogic = serviceLogic;
            this.visitLogic = visitLogic;
            this.medicineLogic = medicineLogic;
        }
        public List<ReportServiceMedicineViewModel> GetServiceMedicine()
        {
            var services = serviceLogic.Read(null);
            var list = new List<ReportServiceMedicineViewModel>();
            foreach (var service in services)
            {
                foreach (var sm in service.ServiceMedicines)
                {
                    var record = new ReportServiceMedicineViewModel
                    {
                        ServiceName = service.ServiceName,
                        MedicineName = sm.Value.Item1,
                        Count = sm.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportVisitsViewModel> GetAllVisits(ReportBindingModel model)
        {
            return visitLogic.Read(null)
            .Where(rec => rec.DateVisit.Date >= model.DateFrom.Value.Date)
            .Where(rec => rec.DateVisit.Date <= model.DateTo.Value.Date)
            .Select(x => new ReportVisitsViewModel
            {
                DateVisit = x.DateVisit,
                ServiceName = x.ServiceName,
                Animal = x.Animal,
                AnimalName = x.AnimalName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
                //ClientFIO=x.ClientFIO
            })
            .ToList();
        }
        public List<ReportServiceViewModel> GetServices()
        {
            var list = new List<ReportServiceViewModel>();
            var services = serviceLogic.Read(null);
            foreach (var service in services)
            {
                list.Add(new ReportServiceViewModel
                {
                    ServiceName = service.ServiceName,
                    Price = Convert.ToInt32(service.Price)
                });
            }
            return list;
        }
        public List<ReportMedicineViewModel> GetMedicines()
        {
            var list = new List<ReportMedicineViewModel>();
            var medicines = medicineLogic.Read(null);
            foreach (var medicine in medicines)
            {
                list.Add(new ReportMedicineViewModel
                {
                    MedicineName = medicine.MedicineName,
                });
            }
            return list;
        }
        public void SaveServicesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocForServices(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список услуг",
                Services = GetServices()
            });
        }
        public void SaveMedicinesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocForMedicines(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список медикаментов",
                Medicines = GetMedicines()
            });
        }
        public void SaveServicesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocForServices(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список услуг",
                Services = GetServices()
            });
        }
        public void SaveMedicinesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocForMedicines(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список медикаменов",
                Medicines = GetMedicines()
            });
        }
        public void SaveAllVisitsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocForVisits(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список визитов",
                Visits = GetAllVisits(model)
            });
        }
        public void SaveServiceMedicinesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocForServiceMedicines(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список услуг с необходимыми медикаментами",
                ServiceMedicines = GetServiceMedicine()
            });
        }
        /*
        public void SendMessage(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            MailAddress to = new MailAddress(model.Email);
            MailMessage message = new MailMessage(from, to);
            message.Attachments.Add(new Attachment(model.FileName));
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
        */
    }
}
