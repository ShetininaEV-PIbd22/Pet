using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicFileImplement.Models
{
    public class ServiceMedicine
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int MedicineId { get; set; }
        public int Count { get; set; }
    }
}
