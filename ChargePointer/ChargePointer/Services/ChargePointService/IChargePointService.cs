using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;

namespace ChargePointer.Services.ChargePointService
{
    public interface IChargePointService : IService<ChargePoint, string>
    {
        void Create(string locationId, ChargePoint chargePoint);
        void Update(string chargePointId);
    }
}