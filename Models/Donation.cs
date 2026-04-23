namespace CareBridgeAPI.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int NeedId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}