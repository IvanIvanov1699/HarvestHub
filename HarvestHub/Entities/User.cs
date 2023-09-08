using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
