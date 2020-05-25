using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PetClinicBusinessLogic.ViewModels
{
    public class VisitViewModels
    {
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Дата визита")]
        public DateTime DateVisit { get; set; }

        [DisplayName("Вид животного")]
        public DateTime Animal{ get; set; }

    }
}
