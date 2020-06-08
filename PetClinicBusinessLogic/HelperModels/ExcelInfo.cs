using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportVisitsViewModel> Visits { get; set; }
    }
}
