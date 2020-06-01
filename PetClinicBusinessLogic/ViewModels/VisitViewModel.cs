using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PetClinicBusinessLogic.ViewModels
{
    public class VisitViewModel
    {
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Дата визита")]
        public DateTime DateVisit { get; set; }
        [DisplayName("Вид животного")]
        public String Animal{ get; set; }
        [DisplayName("Имя животного")]
        public String AnimalName { get; set; }
        public Dictionary<int, (string, int)> Services { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public VisitStatus Status { get; set; }

    }
}
