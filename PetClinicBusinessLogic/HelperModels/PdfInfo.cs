using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportServiceMedicineViewModel> ServiceMedicines { get; set; }
    }
}
