using PetClinicBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class VisitViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        
        [DataMember]
        [DisplayName("Услуга")]
        public string ServiceName { get; set; }

        [DataMember]
        [DisplayName("Вид животного")]
        public string Animal { get; set; }

        [DataMember]
        [DisplayName("Имя животного")]
        public string AnimalName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
        
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        
        [DataMember]
        [DisplayName("Статус")]
        public VisitStatus Status { get; set; }
        
        [DataMember]
        [DisplayName("Дата визита")]
        public DateTime DateVisit { get; set; }
        
    }
}
