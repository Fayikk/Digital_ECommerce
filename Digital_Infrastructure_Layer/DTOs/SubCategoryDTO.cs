using Digital_Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Infrastructure_Layer.DTOs
{
    public class SubCategoryDTO
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Guid MainCategoryId { get; set; }
    }
}
