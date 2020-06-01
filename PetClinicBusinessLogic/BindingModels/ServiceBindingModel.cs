using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.BindingModels
{
    class ServiceBindingModel
    {
        public int? Id { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ServiceMedicines { get; set; }
    }
}
