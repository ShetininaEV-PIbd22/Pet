using System;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    [DataContract]
    public class CreateVisitBindingModel
    {
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        public string ClientFIO { set; get; }
        [DataMember]
        public string Animal { get; set; }
        [DataMember]
        public string AnimalName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        public DateTime DataVisit { get; set; }
    }
}
