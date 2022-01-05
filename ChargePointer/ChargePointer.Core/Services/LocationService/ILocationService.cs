using System.Collections.Generic;
using ChargePointer.Core.RequestModels;
using ChargePointer.Infrastructure.Domain.Entities;


namespace ChargePointer.Core.Services.LocationService
{
    public interface ILocationService : IService<Location, string>
    {
        void PatchUpdate(string id, PatchLocationRequestModel patchLocationRequestModel);
        void UpdateLocationChargePoints(string locationId, ChargePointRequestModel chargePointRequestModel);
    }
}