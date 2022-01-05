using System.Collections.Generic;
using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Core.RequestModels
{
    public class ChargePointRequestModel
    {
        public string LocationId { get; set; }
        public List<ChargePoint> ChargePoints { get; set; }
    }
}