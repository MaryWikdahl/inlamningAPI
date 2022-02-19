using InlamningsupgiftApi.Models.Entities;

namespace InlamningsupgiftApi.Models
{
    public class Order
    {

        public Order(int id)
        {
            Id = id;
          
        }
        public Order()
        {

        }
        public Order(int id, DateTime orderTime, string status, int customerId, List<OrderedProducts> products)
        {
            Id = id;
            OrderTime = orderTime;
            Status = status;
            CustomerId = customerId;
            Products = products;
        }

        public Order(int id, DateTime orderTime, string status, int customerId, List<OrderedProducts> products, double totalPrice)
        {
            Id = id;
            OrderTime = orderTime;
            Status = status;
            CustomerId = customerId;
            Products = products;
            TotalPrice = totalPrice;
        }

        public int Id { get; set; }
       
        public DateTime OrderTime { get; set; }

       
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public List<OrderedProducts> Products { get; set; }
        public double TotalPrice { get; set; }
       
    }

   

   

  
}

