using System.Collections.Generic;
using ChargePointer.Domain.Entities;

namespace ChargePointer.Repositories.ChargePointRepository
{
    public interface IChargePointRepository : IRepository<ChargePoint, string>
    {
        void Update(string chargePointId);
        List<ChargePoint> GetChargePointsByLocationId(string locationId);
    }
}