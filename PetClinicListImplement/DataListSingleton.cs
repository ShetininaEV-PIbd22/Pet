using PetClinicListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicListImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Visit> Visits { get; set; }
        private DataListSingleton()
        {
            Clients = new List<Client>();
            Visits = new List<Visit>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
                instance = new DataListSingleton();
            return instance;
        }
    }
}
