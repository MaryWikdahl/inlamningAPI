using System.ComponentModel.DataAnnotations;

namespace InlamningsupgiftApi.Models.Entities
{
    public class OrderedProductsEntity
    {
        public OrderedProductsEntity(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
