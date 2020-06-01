using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinicDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DateRegister { get; set; }
        [Required]
        public ClientStatus Status { get; set; }
    }
}
