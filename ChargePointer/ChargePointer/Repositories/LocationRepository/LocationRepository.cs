using ChargePointer.Data;
using ChargePointer.Domain.Entities;

namespace ChargePointer.Repositories.LocationRepository
{
    public class LocationRepository : GenericRepository<Location, string>, ILocationRepository
    {
        public LocationRepository(ChargePointerDbContext dbContext) : base(dbContext)
        {
        }
    }
}