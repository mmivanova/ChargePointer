using ChargePointer.Data;
using ChargePointer.Domain.Entities;

namespace ChargePointer.Repositories.ChargePointRepository
{
    public class ChargePointRepository : GenericRepository<ChargePoint, string>, IChargePointRepository
    {
        public ChargePointRepository(ChargePointerDbContext dbContext) : base(dbContext)
        {
        }
    }
}