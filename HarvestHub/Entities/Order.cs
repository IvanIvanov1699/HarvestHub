using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderFull { get; set; }
        public string AddressFull { get; set; }
        public string RecipientFullName { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string RecipientEmail { get; set; }
        public string AddressExtraInfo { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }

    }
}
