using System.Collections.Generic;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;
using ChargePointer.Presentation.Models.LocationModel;

namespace ChargePointer.Services.LocationService
{
    public interface ILocationService : IService<Location, string>
    {
        void PatchUpdate(string id, PatchLocationRequestModel patchLocationRequestModel);
        void UpdateLocationChargePoints(ChargePointRequestModel chargePointRequestModel);
    }
}