using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Province { get; set; }
        public string City { get; set; } 
        public int PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ExtraInfo { get; set; }
        
        // Foreign key property
        [ForeignKey("User")]
        public string UserName { get; set; }

        // Navigation property for the User entity
        public User User { get; set; }
    }
}
