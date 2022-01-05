using ChargePointer.Core.RequestModels;
using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Core.Services.ChargePointService
{
    public interface IChargePointService : IService<ChargePoint, string>
    {
        void UpdateChargePoints(ChargePointRequestModel chargePointRequestModel);
        void CreateNewChargePointsForLocation(ChargePointRequestModel chargePointRequestModel);
    }
}