using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.BindingModels
{
    public class ClientBindingModels
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public DateTime DateRegister  { get; set; }
        public ClientStatus Status { get; set; }

    }
}
