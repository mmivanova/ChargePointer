using System;
using System.Collections.Generic;
using AutoMapper;
using ChargePointer.Domain.Entities;
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

        public void Create(string locationId, ChargePoint chargePoint)
        {
            chargePoint.LocationId = locationId;
            _repository.Create(chargePoint);
        }

        public List<ChargePoint> GetChargePointsByLocationId(string locationId)
        {
            return _repository.GetChargePointsByLocationId(locationId);
        }

        public override void Update(ChargePoint chargePoint)
        {
            var chargePointToUpdate = MapChangesToChargePoint(chargePoint);
            base.Update(chargePointToUpdate);
        }

        private ChargePoint MapChangesToChargePoint(ChargePoint chargePoint)
        {
            var entityId = chargePoint.ChargePointId;
            var original = _repository.Get(entityId);
            var locationToUpdate = _mapper.Map(chargePoint, original);
            locationToUpdate.LastUpdated = DateTime.Now;

            return locationToUpdate;
        }
    }
}