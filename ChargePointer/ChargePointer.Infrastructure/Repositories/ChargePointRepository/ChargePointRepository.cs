using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ChargePointer.Infrastructure.Data;
using ChargePointer.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChargePointer.Infrastructure.Repositories.ChargePointRepository
{
    public class ChargePointRepository : GenericRepository<ChargePoint, string>, IChargePointRepository
    {
        private readonly ChargePointerDbContext _dbContext;
        private readonly DbSet<ChargePoint> _table;

        public ChargePointRepository(ChargePointerDbContext dbContext) :
            base(dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.ChargePoints;
        }

        public void Update(string chargePointId)
        {
            var chargePoint = _table.Find(chargePointId);
            Update(chargePoint);
        }
        
        public List<ChargePoint> GetChargePointsByLocationId(string locationId)
        {
            var chargePoints = _table.FromSqlRaw($@"  SELECT cp.ChargePointId, cp.FloorLevel, cp.[Status], cp.LastUpdated, cp.LocationId
                                    from [dbo].[ChargePoints] cp
                                    where cp.LocationId = '{locationId}';").ToList();
            return chargePoints;
        }
    }
}