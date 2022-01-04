using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web;
using WCF_application.Dtos;

namespace WCF_application.Dtos
{
    [DataContract]
    public class Client
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        public string _firstName { get; private set; }
        [DataMember]
        public string _lastName { get; private set; }
        [DataMember]
        public string _email { get; private set; }
        [DataMember]
        public string _phone { get; private set; }
        [DataMember]
        public string _siret { get; private set; }
        [DataMember]
        private List<Address> _addresses;
        [DataMember]
        private List<Stock> _stocks;


    }
}