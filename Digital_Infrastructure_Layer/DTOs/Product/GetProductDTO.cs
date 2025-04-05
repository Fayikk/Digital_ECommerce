using Digital_Domain_Layer.Entities;
using Digital_Domain_Layer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Infrastructure_Layer.DTOs.Product
{
    public class GetProductDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public string Color { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
