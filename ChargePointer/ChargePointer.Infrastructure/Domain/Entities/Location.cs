namespace ChargePointer.Infrastructure.Domain.Entities
{
    public class Location
    {
        public string LocationId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public List<ChargePoint> ChargePoints { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}