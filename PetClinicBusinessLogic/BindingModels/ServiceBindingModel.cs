using System.Collections.Generic;

namespace PetClinicBusinessLogic.BindingModels
{
    /// <summary>     
    /// Изделие, изготавливаемое в кондитерской     
    /// </summary> 
    public class ServiceBindingModel
    {
        public int? Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ServiceMedicines { get; set; }
    }
}
