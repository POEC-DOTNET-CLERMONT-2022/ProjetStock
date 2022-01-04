using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_application.Dtos
{
    [DataContract]
    public class Address
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        public string _address_line_1 { get; private set; }
        [DataMember]
        public string _address_line_2 { get; private set; }
        [DataMember]
        public string _codePostal { get; private set; }
        [DataMember]
        public string _city { get; private set; }
        [DataMember]
        public string _country { get; private set; }

  


    }
}