using PetClinicBusinessLogic.Enums;
using System;

namespace PetClinicListImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string Animal { get; set; }
        public string AnimalName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public VisitStatus Status { get; set; }
        public DateTime DateVisit { get; set; }
    }
}
