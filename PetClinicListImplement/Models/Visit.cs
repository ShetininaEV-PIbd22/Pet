using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicListImplement.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientFIO { set; get; }
        public DateTime DateVisit { get; set; }
        public String Animal { get; set; }
        public String AnimalName { get; set; }
        //public Dictionary<int, (string, int)> Services { get; set; }
        public decimal Sum { get; set; }
        public VisitStatus Status { get; set; }
    }
}
