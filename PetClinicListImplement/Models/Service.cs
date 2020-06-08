using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicListImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в кондитерской
    /// </summary>
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
