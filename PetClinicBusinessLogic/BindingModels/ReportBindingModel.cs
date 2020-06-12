using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public int ClientId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<ReportVisitsViewModel> Visits { get; set; }
        public string Email { get; set; }
    }
}
