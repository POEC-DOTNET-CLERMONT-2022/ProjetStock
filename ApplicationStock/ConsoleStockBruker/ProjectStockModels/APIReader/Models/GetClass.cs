using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.APIReader.Models
{

    public class GetClass
    {
        [DataMember]
        [Required]
        public Guid Id { get; set; }

    }
}
