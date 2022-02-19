namespace InlamningsupgiftApi.Models
{
    public class ProductUpdateModel
    {

        public ProductUpdateModel()
        {
        }

        public ProductUpdateModel(string name, string description, decimal price, int categoryId)
        {
        
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

       
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
