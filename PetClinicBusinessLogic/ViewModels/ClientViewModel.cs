using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PetClinicBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        //[Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string FIO { get; set; }

        //[Column(title: "Логин", width: 150)]
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        //[Column(title: "Почта", width: 150)]
        [DataMember]
        public string Email { get; set; }
        
        //[Column(title: "Телефон", width: 150)]
        [DataMember]
        public string Phone { get; set; }

        public override List<string> Properties() => new List<string>
        {
            "Id",
            "FIO",
            "Login",
            "Email",
            "Phone",
        };
    }
}
