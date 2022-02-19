using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningsupgiftApi.Models.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {

        }

        public CustomerEntity( string FirstName, string LastName, string Email, string Password)
        {
          
            FirstName = FirstName;
            LastName = LastName;
            Email = Email;
            Password = Password;
           
        }

        public CustomerEntity( string firstName, string lastName, string email, string address, string city, int zipCode, string password)
        {
           
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            ZipCode = zipCode;
            Password = password;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public int ZipCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

     

    }
}
