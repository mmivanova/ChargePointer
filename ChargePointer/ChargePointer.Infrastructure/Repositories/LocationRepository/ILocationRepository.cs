using ChargePointer.Infrastructure.Domain.Entities;

namespace ChargePointer.Infrastructure.Repositories.LocationRepository
{
    public interface ILocationRepository : IRepository<Location, string>
    {
        void PatchUpdate(Location locationToUpdate);
    }
}