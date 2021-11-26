using System.Collections.Generic;
using System.Security.AccessControl;
using ChargePointer.Domain.Entities;

namespace ChargePointer.Presentation.Models.ChargePointModel
{
    public class ChargePointResponseModel
    {
        public List<ChargePoint> ChargePoints { get; set; }
    }
}