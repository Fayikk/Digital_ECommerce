using Digital_Domain_Layer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Digital_Domain_Layer.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
