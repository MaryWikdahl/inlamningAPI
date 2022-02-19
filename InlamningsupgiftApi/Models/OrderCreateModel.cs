using InlamningsupgiftApi.Models.Entities;

namespace InlamningsupgiftApi.Models
{
    public class OrderCreateModel
    {
        public OrderCreateModel()
        {

        }

        public OrderCreateModel(List<OrderedProducts> products)
        {
            Products = products;
        }

        public List<OrderedProducts> Products { get; set; }
        public int CustomerId { get; set; }
    }

    public class OrderedProducts 
    {
        public OrderedProducts(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
