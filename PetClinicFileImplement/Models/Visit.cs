using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicFileImplement.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        //public int? ImplementerId { get; set; }
        public int ServiceId { get; set; }
        public string ClientFIO { get; set; }
        public string Animal { get; set; }
        public string AnimalName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public VisitStatus Status { get; set; }
        public DateTime DateVisit { get; set; }
    }
}
