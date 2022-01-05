using AutoMapper;
using ChargePointer.Core.RequestModels;
using ChargePointer.Infrastructure.Domain.Entities;
using ChargePointer.Presentation.Presentation.Models.ChargePointModel;
using ChargePointer.Presentation.Presentation.Models.LocationModel;

namespace ChargePointer.Presentation.Mapper
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
            CreateMap<ChargePoint, ChargePoint>();
        }
    }
}