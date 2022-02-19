namespace InlamningsupgiftApi.Models
{
    public class ProductCreateModel
    {
        public ProductCreateModel()
        {
        }

        public ProductCreateModel(string name, string description, decimal price, int categoryId)
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
