using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ChargePointer.Domain.Entities;
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
            if (id != patchLocationRequestModel.LocationId)
            {
                throw new ArgumentException("The object you are trying to update and the passed ID doesn't match");
            }

            var locationToUpdate = MapPatchLocationModelToLocation(patchLocationRequestModel);
            _repository.PatchUpdate(locationToUpdate);
        }

        //TODO 
        public List<ChargePoint> UpdateChargePoints(string locationId, List<ChargePoint> chargePoints)
        {
            var locationsChargePoints = Get(locationId).ChargePoints;

            return _chargePointService.GetAll().ToList();
        }

        private List<ChargePoint> GetChargePointsToBeUpdated(List<ChargePoint> requestBodyChargePoints, List<ChargePoint> databaseChargePoints)
        {
            var chargePointsToUpdate = new List<ChargePoint>();
            throw new NotImplementedException();
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