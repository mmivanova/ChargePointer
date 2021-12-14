using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;
using ChargePointer.Repositories.ChargePointRepository;

namespace ChargePointer.Services.ChargePointService
{
    public class ChargePointService : GenericService<ChargePoint, string>, IChargePointService
    {
        private readonly IChargePointRepository _repository;
        private readonly IMapper _mapper;

        public ChargePointService(IChargePointRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override void Update(ChargePoint chargePoint)
        {
            var chargePointToUpdate = MapChangesToChargePoint(chargePoint);
            base.Update(chargePointToUpdate);
        }

        public void UpdateChargePoints(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePointsToUpdate = GetChargePointsToBeUpdated(chargePointRequestModel);

            if (chargePointsToUpdate is null) return;
            foreach (var chargePoint in chargePointsToUpdate)
            {
                Update(chargePoint);
            }
        }

        public void CreateNewChargePointsForLocation(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePoints = GetChargePointsThatAreNotInDatabase(chargePointRequestModel);
            foreach (var chargePoint in chargePoints)
            {
                Create(chargePointRequestModel.LocationId, chargePoint);
            }
        }

        private List<ChargePoint> GetChargePointsToBeUpdated(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePointsToUpdate = new List<ChargePoint>();
            chargePointsToUpdate.AddRange(GetChargePointsToBeRemoved(chargePointRequestModel));
            chargePointsToUpdate.AddRange(GetExistingChargePointsToBeUpdated(chargePointRequestModel));

            return chargePointsToUpdate;
        }

        private List<ChargePoint> GetChargePointsToBeRemoved(ChargePointRequestModel chargePointRequestModel)
        {
            var chargePointsToRemove = GetChargePointsThatAreNotInRequestModel(chargePointRequestModel);
            SetStatusToRemovedToChargePoints(chargePointsToRemove);
            return chargePointsToRemove;
        }

        private List<ChargePoint> GetChargePointsThatAreNotInRequestModel(
            ChargePointRequestModel chargePointRequestModel)
        {
            var databaseChargePoints = GetChargePointsByLocationId(chargePointRequestModel.LocationId);

            if (IsNullOrEmpty(databaseChargePoints))
            {
                return new List<ChargePoint>();
            }

            var list = databaseChargePoints
                .Where(dbcp =>
                    chargePointRequestModel.ChargePoints.All(rmcp => rmcp.ChargePointId != dbcp.ChargePointId))
                .ToList();

            return list;
        }

        private List<ChargePoint> GetExistingChargePointsToBeUpdated(ChargePointRequestModel chargePointRequestModel)
        {
            var databaseChargePoints = GetChargePointsByLocationId(chargePointRequestModel.LocationId);

            if (IsNullOrEmpty(databaseChargePoints))
            {
                return new List<ChargePoint>();
            }

            var existingChargePoints = chargePointRequestModel.ChargePoints
                .Join(databaseChargePoints,
                rmcp => rmcp.ChargePointId,
                dbcp => dbcp.ChargePointId,
                (rmcp, dbcp) => rmcp)
                .ToList();

            SetLocationIdToChargePoints(chargePointRequestModel.LocationId, existingChargePoints);

            return existingChargePoints;
        }

        private static void SetLocationIdToChargePoints(string locationId, List<ChargePoint> existingChargePoints)
        {
            foreach (var chargePoint in existingChargePoints)
            {
                chargePoint.LocationId = locationId;
            }
        }

        private List<ChargePoint> GetChargePointsThatAreNotInDatabase(
            ChargePointRequestModel chargePointRequestModel)
        {
            var databaseChargePoints = GetChargePointsByLocationId(chargePointRequestModel.LocationId);

            if (IsNullOrEmpty(databaseChargePoints))
            {
                return chargePointRequestModel.ChargePoints;
            }

            var list = chargePointRequestModel.ChargePoints
                .Where(rmcp => databaseChargePoints.All(dbcp => dbcp.ChargePointId != rmcp.ChargePointId))
                .ToList();

            return list;
        }


        private ChargePoint MapChangesToChargePoint(ChargePoint chargePoint)
        {
            var entityId = chargePoint.ChargePointId;
            var original = _repository.Get(entityId);
            var locationToUpdate = _mapper.Map(chargePoint, original);
            locationToUpdate.LastUpdated = DateTime.Now;

            return locationToUpdate;
        }

        private List<ChargePoint> GetChargePointsByLocationId(string locationId)
        {
            return _repository.GetChargePointsByLocationId(locationId);
        }

        private void Create(string locationId, ChargePoint chargePoint)
        {
            try
            {
                chargePoint.LocationId = locationId;
                _repository.Create(chargePoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void SetStatusToRemovedToChargePoints(List<ChargePoint> chargePointsToRemove)
        {
            foreach (var chargePoint in chargePointsToRemove)
            {
                chargePoint.Status = "Removed";
            }
        }

        private bool IsNullOrEmpty(List<ChargePoint> chargePoints)
        {
            return chargePoints == null || chargePoints.Count == 1;
        }
    }
}