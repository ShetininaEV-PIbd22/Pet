using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.BindingModels
{
    public class VisitBindingModels
    {
        public int? Id { get; set; }
        public DateTime DateVisit { get; set; }
        public String Animal { get; set; }
        public String AnimalName { get; set; }
        public Dictionary<int, (string, int)> Services { get; set; }
        public decimal Price { get; set; }
        public VisitStatus Status { get; set; }

    }
}
