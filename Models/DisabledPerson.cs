namespace CareBridgeAPI.Models
{
    public class DisabledPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisabilityType { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}