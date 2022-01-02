using System;
using AutoMapper;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;
using ChargePointer.Presentation.Models.LocationModel;
using ChargePointer.Repositories.LocationRepository;
using ChargePointer.Services.ChargePointService;

namespace ChargePointer.Services.LocationService
{
    public class LocationService : GenericService<Location, string>, ILocationService
    {
        private readonly ILocationRepository _repository;

        private readonly IChargePointService _chargePointService;
        private readonly IMapper _mapper;
        
        public LocationService(ILocationRepository repository, IChargePointService chargePointService, IMapper mapper)
            : base(repository)
        {
            _repository = repository;
            _chargePointService = chargePointService;
            _mapper = mapper;
        }

        public void PatchUpdate(string id, PatchLocationRequestModel patchLocationRequestModel)
        {
            ValidateLocationId(id, patchLocationRequestModel.LocationId);

            var locationToUpdate = MapPatchLocationModelToLocation(patchLocationRequestModel);
            _repository.PatchUpdate(locationToUpdate);
        }
        
        public void UpdateLocationChargePoints(string locationId, ChargePointRequestModel chargePointRequestModel)
        {
            ValidateLocationId(locationId, chargePointRequestModel.LocationId);
            _chargePointService.UpdateChargePoints(chargePointRequestModel);
            _chargePointService.CreateNewChargePointsForLocation(chargePointRequestModel);
        }

        private void ValidateLocationId(string locationId1, string locationId2)
        {
            if (!locationId1.Equals(locationId2))
            {
                throw new ArgumentException("The object you are trying to update and the ID from the URL doesn't match");
            }
        }

        private Location MapPatchLocationModelToLocation(PatchLocationRequestModel patchLocationRequestModel)
        {
            var entityId = patchLocationRequestModel.LocationId;
            var original = _repository.Get(entityId);
            var locationToUpdate = _mapper.Map(patchLocationRequestModel, original);
            locationToUpdate.LastUpdated = DateTime.Now;

            return locationToUpdate;
        }
    }
}