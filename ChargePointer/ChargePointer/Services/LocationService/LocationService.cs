using ChargePointer.Domain.Entities;
using ChargePointer.Repositories;
using ChargePointer.Repositories.LocationRepository;

namespace ChargePointer.Services.LocationService
{
    public class LocationService : GenericService<Location, string>, ILocationService
    {
        public LocationService(ILocationRepository repository) : base(repository)
        {
        }
    }
}