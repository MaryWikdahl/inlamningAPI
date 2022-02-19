namespace InlamningsupgiftApi.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Customer(int id, string firstName, string lastName, string email, string address, string city, int zipCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            ZipCode = zipCode;
        }

        public int Id { get; set; }

        
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

       
        public string Email { get; set; }


        public string Address { get; set; }

      
        public string City { get; set; }

      
        public int ZipCode { get; set; }

    }
}
