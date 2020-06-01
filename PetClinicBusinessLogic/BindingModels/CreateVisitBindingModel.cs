using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PetClinicBusinessLogic.BindingModels
{
    public class CreateVisitBindingModel
    {
        public int ClientId { set; get; }
        [DataMember]
        public string ClientFIO { set; get; }
        [DataMember]
        //public int ServiseId { get; set; }
        public Dictionary<int, (string, int)> Services { get; set; }
        [DataMember]
        public String Animal { get; set; }
        [DataMember]
        public String AnimalName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
