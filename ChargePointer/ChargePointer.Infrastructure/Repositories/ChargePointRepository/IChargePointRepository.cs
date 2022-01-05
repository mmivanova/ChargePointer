using System.Collections.Generic;
using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Infrastructure.Repositories.ChargePointRepository
{
    public interface IChargePointRepository : IRepository<ChargePoint, string>
    {
        void Update(string chargePointId);
        List<ChargePoint> GetChargePointsByLocationId(string locationId);
    }
}