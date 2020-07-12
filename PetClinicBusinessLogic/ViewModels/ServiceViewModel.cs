using PetClinicBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    // Услуги
    [DataContract]
    public class ServiceViewModel : BaseViewModel
    {
        
        [Column(title: "Название услуги", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ServiceName { get; set; }

        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        
        [DataMember]
        public Dictionary<int, (string, int)> ServiceMedicines { get; set; }

        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ServiceName",
            "Price"
        };
    }
}
