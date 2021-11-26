using System;
using Type = ChargePointer.Domain.Entities.Type;

namespace ChargePointer.Presentation.Models.LocationModel
{
    public class LocationResponseModel
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}