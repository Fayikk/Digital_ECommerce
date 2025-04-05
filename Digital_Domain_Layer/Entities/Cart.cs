using Digital_Domain_Layer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Domain_Layer.Entities
{
    public class Cart : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }    
        public virtual User User { get;set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
