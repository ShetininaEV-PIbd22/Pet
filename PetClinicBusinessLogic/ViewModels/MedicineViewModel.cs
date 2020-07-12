using PetClinicBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    public class MedicineViewModel : BaseViewModel
    {
        [Column(title: "Название медикамена", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string MedicineName { get; set; }

        public override List<string> Properties() => new List<string>
        {
            "Id",
            "MedicineName"
        };
    }
}
