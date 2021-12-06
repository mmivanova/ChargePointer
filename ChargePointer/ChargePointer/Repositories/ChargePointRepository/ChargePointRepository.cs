using ChargePointer.Data;
using ChargePointer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChargePointer.Repositories.ChargePointRepository
{
    public class ChargePointRepository : GenericRepository<ChargePoint, string>, IChargePointRepository
    {
        private readonly ChargePointerDbContext _dbContext;
        private readonly DbSet<ChargePoint> _table;

        public ChargePointRepository(ChargePointerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.ChargePoints;
        }
    }
}