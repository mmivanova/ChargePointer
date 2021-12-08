using ChargePointer.Domain.Entities;
using ChargePointer.Repositories.ChargePointRepository;

namespace ChargePointer.Services.ChargePointService
{
    public class ChargePointService : GenericService<ChargePoint, string>, IChargePointService
    {
        private readonly IChargePointRepository _chargePointRepository;

        public ChargePointService(IChargePointRepository repository) : base(repository)
        {
            _chargePointRepository = repository;
        }

        public void Create(string locationId, ChargePoint chargePoint)
        {
            chargePoint.LocationId = locationId;
            _chargePointRepository.Create(chargePoint);
        }

        public void Update(string chargePointId)
        {
            _chargePointRepository.Update(chargePointId);
        }
    }
}