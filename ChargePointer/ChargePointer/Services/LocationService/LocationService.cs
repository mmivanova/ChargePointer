using System;
using AutoMapper;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.LocationModel;
using ChargePointer.Repositories.LocationRepository;

namespace ChargePointer.Services.LocationService
{
    public class LocationService : GenericService<Location, string>, ILocationService
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void PatchUpdate(string id, PatchLocationRequestModel patchLocationRequestModel)
        {
            if (id != patchLocationRequestModel.LocationId)
            {
                throw new ArgumentException("The object you are trying to update and the passed ID doesn't match");
            }
            
            var locationToUpdate = MapPatchLocationModelToLocation(patchLocationRequestModel);
            _repository.PatchUpdate(locationToUpdate);
        }

        private Location MapPatchLocationModelToLocation(PatchLocationRequestModel patchLocationRequestModel)
        {
            var entityId = patchLocationRequestModel.LocationId;
            var original = _repository.Get(entityId);
            var locationToUpdate = _mapper.Map(patchLocationRequestModel, original);
            locationToUpdate.LastUpdated = DateTime.Now;
            
            return locationToUpdate;
        }
    }
}