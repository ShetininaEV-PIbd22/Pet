using PetClinicBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PetClinicBusinessLogic.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DataMember]
        [DisplayName("ФИО")]
        public string FIO { get; set; }
        [DataMember]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DataMember]
        [DisplayName("Электронная почта")]
        public string Email { get; set; }
        [DataMember]
        [DisplayName("Контактный телефон")]
        public string Phone { get; set; }
        [DataMember]
        [DisplayName("Дата регистрации")]
        public DateTime DateRegister { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public ClientStatus Status { get; set; }
    }
}
