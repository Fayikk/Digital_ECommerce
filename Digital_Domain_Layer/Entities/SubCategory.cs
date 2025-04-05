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
    public class SubCategory : BaseEntity
    {   
        public string CategoryName { get; set; }    
        public string CategoryDescription { get; set; }
        [ForeignKey(nameof(MainCategory))]
        public Guid MainCategoryId { get; set; }
        [JsonIgnore]
        public virtual MainCategory MainCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
