using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicDatabaseImplement.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        
        public String ClientFIO { get; set; }
        public DateTime DateVisit { get; set; }
        public String Animal { get; set; }
        public String AnimalName { get; set; }
        public Dictionary<int, (string, int)> Services { get; set; }
        public decimal Sum { get; set; }
        public VisitStatus Status { get; set; }
    }
}
