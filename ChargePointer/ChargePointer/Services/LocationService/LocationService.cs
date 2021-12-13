using System;
using System.Collections.Generic;
using System.Linq;
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
            if (id != patchLocationRequestModel.LocationId)
            {
                throw new ArgumentException("The object you are trying to update and the passed ID doesn't match");
            }

            var locationToUpdate = MapPatchLocationModelToLocation(patchLocationRequestModel);
            _repository.PatchUpdate(locationToUpdate);
        }

        //TODO 
        public List<ChargePoint> UpdateLocationChargePoints(ChargePointRequestModel chargePointRequestModel)
        {
            UpdateChargePoints(chargePointRequestModel);
            CreateNewChargePointsForLocation(chargePointRequestModel);
            return _chargePointService.GetAll().ToList();
        }

        private List<ChargePoint> GetChargePointsThatAreNotInRequestModel(
            ChargePointRequestModel chargePointRequestModel)
        {
            var databaseChargePoints = GetChargePointsByLocationId(chargePointRequestModel.LocationId);

            if (databaseChargePoints is null)
            {
                return new List<ChargePoint>();
            }
            
            var list = databaseChargePoints.Where(p => chargePointRequestModel.ChargePoints.All(p2 => p2.ChargePointId == p.ChargePointId));

            return list.ToList();
            
        }

        private void SetStatusToRemovedToChargePoints(List<ChargePoint> chargePointsToRemove)
        {
            foreach (var chargePoint in chargePointsToRemove)
            {
                chargePoint.Status = "Removed";
            }
        }

        private List<ChargePoint> GetChargePointsToBeRemoved(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePointsToRemove = GetChargePointsThatAreNotInRequestModel(chargePointRequestModel);
            SetStatusToRemovedToChargePoints(chargePointsToRemove);
            return chargePointsToRemove;
        }

        private List<ChargePoint> GetChargePointsThatAreNotInDatabase(
            ChargePointRequestModel chargePointRequestModel)
        {
            var databaseChargePoints = GetChargePointsByLocationId(chargePointRequestModel.LocationId);

            if (databaseChargePoints is null || databaseChargePoints.Count == 0)
            {
                return chargePointRequestModel.ChargePoints;
            }

            return chargePointRequestModel.ChargePoints
                .Except(databaseChargePoints, EqualityComparer<ChargePoint>.Default)
                .ToList();
        }

        private Location MapPatchLocationModelToLocation(PatchLocationRequestModel patchLocationRequestModel)
        {
            var entityId = patchLocationRequestModel.LocationId;
            var original = _repository.Get(entityId);
            var locationToUpdate = _mapper.Map(patchLocationRequestModel, original);
            locationToUpdate.LastUpdated = DateTime.Now;

            return locationToUpdate;
        }

        private void CreateNewChargePointsForLocation(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePoints = GetChargePointsThatAreNotInDatabase(chargePointRequestModel);
            foreach (var chargePoint in chargePoints)
            {
                _chargePointService.Create(chargePointRequestModel.LocationId, chargePoint);
            }
        }

        private List<ChargePoint> GetChargePointsToBeUpdated(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePointsToUpdate = new List<ChargePoint>();
            chargePointsToUpdate.AddRange(GetChargePointsToBeRemoved(chargePointRequestModel));
            chargePointsToUpdate.AddRange(GetExistingChargePointsToBeUpdated(chargePointRequestModel));

            return chargePointsToUpdate;
        }

        private List<ChargePoint> GetExistingChargePointsToBeUpdated(ChargePointRequestModel chargePointRequestModel)
        {
            var databaseChargePoints = GetChargePointsByLocationId(chargePointRequestModel.LocationId);

            //var existingChargePoints =  
            
            if (databaseChargePoints is null || databaseChargePoints.Count == 0)
            {
                return new List<ChargePoint>();
            }

            return chargePointRequestModel.ChargePoints
                .Intersect(databaseChargePoints, EqualityComparer<ChargePoint>.Default)
                .ToList();
        }

        private void UpdateChargePoints(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePointsToUpdate = GetChargePointsToBeUpdated(chargePointRequestModel);

            if (chargePointsToUpdate is null) return;
            foreach (var chargePoint in chargePointsToUpdate)
            {
                _chargePointService.Update(chargePoint);
            }
        }
        
        private List<ChargePoint> GetChargePointsByLocationId(string locationId)
        {
            return _chargePointService.GetChargePointsByLocationId(locationId);
        }
        
    }
}