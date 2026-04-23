namespace CareBridgeAPI.Models
{
    public class Need
    {
        public int Id { get; set; }
        public int DisabledPersonId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}