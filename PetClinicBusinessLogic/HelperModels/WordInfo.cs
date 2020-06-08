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
        public List<ServiceViewModel> Services { get; set; }
    }
}
