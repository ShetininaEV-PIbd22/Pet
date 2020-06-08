using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDatabaseImplement.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ServiceMedicine ServiceMedicine { get; set; }

        public virtual List<Visit> Visits { get; set; }
    }
}
