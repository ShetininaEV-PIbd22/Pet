using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDatabaseImplement.Models
{
    public class ServiceMedicine
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int MedicineId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Service Service { get; set; }
    }
}
