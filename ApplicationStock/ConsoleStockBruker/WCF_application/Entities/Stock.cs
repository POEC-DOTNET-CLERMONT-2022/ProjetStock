using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_application.Dtos
{
    [DataContract]
    public class Stock
    {
      
        [DataMember]
        public Guid _id { get; set; }
        [DataMember]
        public string _name { get; set; }
        [DataMember]
        public float _value { get;  set; }
        [DataMember]
        public string _entrepriseName { get; set; }
        [DataMember]
        private List<Client> _clients { get; set; }




    }
}