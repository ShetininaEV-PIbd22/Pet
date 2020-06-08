using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
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
        [DisplayName("Почта")]
        public string Email { get; set; }
        [DataMember]
        [DisplayName("Телефон")]
        public string Phone { get; set; }


    }
}
