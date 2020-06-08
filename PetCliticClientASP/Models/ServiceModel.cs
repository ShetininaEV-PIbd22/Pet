using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicRestApi.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
