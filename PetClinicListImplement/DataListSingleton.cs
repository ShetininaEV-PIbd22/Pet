using PetClinicListImplement.Models;
using System.Collections.Generic;

namespace PetClinicListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Medicine> Medicines { get; set; }

        public List<Visit> Visits { get; set; }

        public List<Service> Services { get; set; }

        public List<ServiceMedicines> ServiceMedicines { get; set; }
        public List<MessageInfo> MessageInfos { get; set; }

        private DataListSingleton() 
        {
            Medicines = new List<Medicine>();
            Clients = new List<Client>();
            Visits = new List<Visit>();
            Services = new List<Service>();
            ServiceMedicines = new List<ServiceMedicines>();
            MessageInfos = new List<MessageInfo>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
                instance = new DataListSingleton();
            return instance;
        }
    }
}