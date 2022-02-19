using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningsupgiftApi.Models.Entities
{
    public class OrderEntity
    {
        public OrderEntity(int customerId)
        {
            CustomerId = customerId;
            OrderTime = DateTime.Now;
            Status = "Påbörjad";
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        [Required]
        public int CustomerId { get; set; }

    }
}
