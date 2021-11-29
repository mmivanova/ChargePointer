using AutoMapper;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.LocationModel;

namespace ChargePointer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocationRequestModel, Location>();
            CreateMap<Location, LocationResponseModel>();
        }
    }
}