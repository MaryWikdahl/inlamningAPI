using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningsupgiftApi.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {

        }
        public ProductEntity( string name, string description, decimal price, int categoryId)
        {
            
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Deleted = false;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
        public bool Deleted { get; set; }
    }
}
