using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.LocationModel;

namespace ChargePointer.Repositories.LocationRepository
{
    public interface ILocationRepository : IRepository<Location, string>
    {
        void PatchUpdate(Location locationToUpdate);
    }
}