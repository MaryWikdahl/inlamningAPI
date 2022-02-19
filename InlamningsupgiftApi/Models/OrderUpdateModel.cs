using InlamningsupgiftApi.Models.Entities;

namespace InlamningsupgiftApi.Models
{
    public class OrderUpdateModel
    {
        public OrderUpdateModel(string status, OrderedProductsEntity orderproduct)
        {
            Status = status;
            this.orderproduct = orderproduct;
        }

        public string Status { get; set; }
   
        public OrderedProductsEntity orderproduct { get; set; }

       
    }
}
