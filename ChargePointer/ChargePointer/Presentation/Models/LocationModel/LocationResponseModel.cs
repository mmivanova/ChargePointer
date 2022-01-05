using System.Collections.Generic;
using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Presentation.Presentation.Models.LocationModel
{
    public class LocationResponseModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public List<ChargePoint> ChargePoints { get; set; }
    }
}