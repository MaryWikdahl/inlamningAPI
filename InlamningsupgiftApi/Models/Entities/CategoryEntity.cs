using System.ComponentModel.DataAnnotations;

namespace InlamningsupgiftApi.Models.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
