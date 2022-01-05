using System.Collections.Generic;
using System.Security.AccessControl;
using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Presentation.Presentation.Models.ChargePointModel
{
    public class ChargePointResponseModel
    {
        public List<ChargePoint> ChargePoints { get; set; }
    }
}