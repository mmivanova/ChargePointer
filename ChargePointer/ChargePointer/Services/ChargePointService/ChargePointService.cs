using ChargePointer.Domain.Entities;
using ChargePointer.Repositories.ChargePointRepository;

namespace ChargePointer.Services.ChargePointService
{
    public class ChargePointService : GenericService<ChargePoint, string>, IChargePointService
    {
        public ChargePointService(IChargePointRepository repository) : base(repository)
        {
        }
    }
}