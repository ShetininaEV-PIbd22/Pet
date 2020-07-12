using PetClinicBusinessLogic.Attributes;
using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    [DataContract]
    public class VisitViewModel : BaseViewModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ServiceId { get; set; }

        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Услуга", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ServiceName { get; set; }

        [Column(title: "Вид животного", width: 100)]
        [DataMember]
        public string Animal { get; set; }

        [Column(title: "Имя животного", width: 100)]
        [DataMember]
        public string AnimalName { get; set; }

        [Column(title: "Количество", width: 50)]
        [DataMember]
        public int Count { get; set; }
        
        [Column(title: "Сумма", width: 50)]
        [DataMember]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        [DataMember]
        public VisitStatus Status { get; set; }

        [Column(title: "Дата визита", width: 100)]
        [DataMember]
        public DateTime DateVisit { get; set; }

        public override List<string> Properties() => new List<string> 
        { 
            "Id", 
            "ClientFIO",
            "ServiceName",
            "Animal",
            "AnimalName",
            "Count", 
            "Sum", 
            "Status", 
            "DateVisit"
        };

    }
}
