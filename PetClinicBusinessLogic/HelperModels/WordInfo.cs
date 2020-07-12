using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportServiceViewModel> Services { get; set; }
        public List<ReportMedicineViewModel> Medicines { get; set; }
    }
}
