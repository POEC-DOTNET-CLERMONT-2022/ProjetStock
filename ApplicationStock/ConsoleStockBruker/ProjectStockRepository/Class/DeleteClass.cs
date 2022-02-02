using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

//TODO : namespace
namespace ProjectStockModels.Models
{
    public class DeleteClass
    {
        [DataMember]
        [Required]
        public Guid _id { get; set; }
        //TODO : nommage 
    }
}
