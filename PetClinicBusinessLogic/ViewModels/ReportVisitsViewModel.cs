using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.ViewModels
{
    public class ReportVisitsViewModel
    {
        public int ClientId { get; set; }
        public DateTime DateVisit { get; set; }
        public string ServiceName { get; set; }
        public string Animal { get; set; }
        public string AnimalName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public VisitStatus Status { get; set; }
    }
}
