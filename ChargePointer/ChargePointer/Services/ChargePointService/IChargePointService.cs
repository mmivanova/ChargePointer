using System.Collections.Generic;
using ChargePointer.Domain.Entities;

namespace ChargePointer.Services.ChargePointService
{
    public interface IChargePointService : IService<ChargePoint, string>
    {
        void Create(string locationId, ChargePoint chargePoint);
        List<ChargePoint> GetChargePointsByLocationId(string locationId);
    }
}