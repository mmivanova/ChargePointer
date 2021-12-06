using System;
using ChargePointer.Data;
using ChargePointer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChargePointer.Repositories.LocationRepository
{
    public class LocationRepository : GenericRepository<Location, string>, ILocationRepository
    {
        private readonly ChargePointerDbContext _dbContext;
        private readonly DbSet<Location> _table;

        public LocationRepository(ChargePointerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Locations;
        }

        public void PatchUpdate(Location locationToUpdate)
        {
            
            if (locationToUpdate is null || _table.Find(locationToUpdate.LocationId) is null)
            {
                throw new InvalidOperationException("This object does not exist.");
            }
            
            _table.Update(locationToUpdate);
            _dbContext.SaveChanges();
        }
    }
}