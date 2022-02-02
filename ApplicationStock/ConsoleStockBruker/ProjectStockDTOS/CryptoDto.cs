using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProjectStockLibrary;

namespace ProjectStockDTOS
{

    public class CryptoDto
    {
        //TODO : inutile pour REST
        [DataMember]
        [Required]

        public Guid _id {get; private set;}

        [DataMember]
        [Required]
        public string? _name {get; set;}

        [DataMember]
        
        public float _value{get; set;}

        [DataMember]
        [Required]
        public List<Client>? _listClient {get; set;}

        [DataMember]
        [Required]
        public List<Market>? _listMarker {get; set;}


    }

}


