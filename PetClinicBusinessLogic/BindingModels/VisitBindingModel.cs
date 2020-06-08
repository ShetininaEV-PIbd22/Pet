using PetClinicBusinessLogic.Enums;
using System;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.BindingModels
{
    /// <summary>     
    /// Заказ     
    /// </summary>   
    public class VisitBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public int ServiceId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Animal { get; set; }
        public string AnimalName { get; set; }
        public VisitStatus Status { get; set; }
        public DateTime DateVisit { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
