using System.Collections.Generic;
using ChargePointer.Domain.Entities;

namespace ChargePointer.Presentation.Models.ChargePointModel
{
    public class ChargePointRequestModel
    {
        public string LocationId { get; set; }
        public List<ChargePoint> ChargePoints { get; set; }
    }
}