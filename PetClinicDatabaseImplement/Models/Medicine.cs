using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDatabaseImplement.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [ForeignKey("MedicineId")]
        public virtual List<ServiceMedicine> ServiceMedicines { get; set; }
    }
}
