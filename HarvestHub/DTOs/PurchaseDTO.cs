using HarvestHub.Entities;

namespace HarvestHub.DTOs
{
    public class PurchaseDTO
    {
        public string OrderFull { get; set; }
        public string AddressFull { get; set; }
        public string RecipientFullName { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string RecipientEmail { get; set; }
        public string AddressExtraInfo { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public string UserName { get; set; }
    }
}
