using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.LocationModel;
using ChargePointer.Services.LocationService;
using Microsoft.AspNetCore.Mvc;

namespace ChargePointer.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController 
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public List<LocationResponseModel> Get()
        {
            var locations = _locationService
                .GetAll()
                .Select(_mapper.Map<LocationResponseModel>)
                .ToList();
            
            return locations;
        }
        
        [HttpGet]
        [Route("{locationId}")]
        public LocationResponseModel Get([FromRoute]string locationId)
        {
            var location = _locationService.Get(locationId);

            var responseModel = _mapper.Map<LocationResponseModel>(location);
            return responseModel;
        }

        [HttpPost]
        public void Create([FromBody] LocationRequestModel locationRequestModel)
        {
            var location = _mapper.Map<Location>(locationRequestModel);
            _locationService.Create(location);
        }
        
    }
}