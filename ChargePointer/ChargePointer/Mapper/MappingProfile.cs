using AutoMapper;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;
using ChargePointer.Presentation.Models.LocationModel;

namespace ChargePointer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocationRequestModel, Location>();
            CreateMap<Location, LocationResponseModel>();
            CreateMap<PatchLocationRequestModel, Location>()
                .ForAllMembers(opts => opts
                    .Condition((_, _, srcMember) => srcMember != null));
            
            CreateMap<ChargePointRequestModel, ChargePoint>();
            CreateMap<ChargePoint, ChargePointResponseModel>();
        }
    }
}