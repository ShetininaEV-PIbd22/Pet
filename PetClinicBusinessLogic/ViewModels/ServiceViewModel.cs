using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в кондитерской
    /// </summary>
    [DataContract]
    public class ServiceViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> ServiceMedicines { get; set; }
    }
}
