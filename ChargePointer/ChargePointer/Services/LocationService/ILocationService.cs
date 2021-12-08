using System.Collections.Generic;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.LocationModel;

namespace ChargePointer.Services.LocationService
{
    public interface ILocationService : IService<Location, string>
    {
        void PatchUpdate(string id, PatchLocationRequestModel patchLocationRequestModel);
        List<ChargePoint> UpdateChargePoints(string locationId, List<ChargePoint> chargePoints);
    }
}