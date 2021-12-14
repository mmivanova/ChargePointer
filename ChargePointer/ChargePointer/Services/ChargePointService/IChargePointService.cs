using System.Collections.Generic;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;

namespace ChargePointer.Services.ChargePointService
{
    public interface IChargePointService : IService<ChargePoint, string>
    {
   
        void UpdateChargePoints(ChargePointRequestModel chargePointRequestModel);
        void CreateNewChargePointsForLocation(ChargePointRequestModel chargePointRequestModel);
    }
}