using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDatabaseImplement.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        [Required]
        public string Animal { get; set; }
        [Required]
        public string AnimalName { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public VisitStatus Status { get; set; }
        [Required]
        public DateTime DateVisit { get; set; }
        public Service Service { get; set; }
        public Client Client { get; set; }
    }
}
