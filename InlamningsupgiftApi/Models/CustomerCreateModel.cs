using InlamningsupgiftApi.Models.Entities;

namespace InlamningsupgiftApi.Models
{
    public class CustomerCreateModel
    {
        public CustomerCreateModel() { }
        public CustomerCreateModel(string firstName, string lastName, string email,string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public CustomerCreateModel(string firstName, string lastName, string email, string password, string address, string city, int zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
            City = city;
            ZipCode = zipCode;
        }

        public string FirstName{ get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Address { get; set; }


        public string City { get; set; }


        public int ZipCode { get; set; }



    }
}
