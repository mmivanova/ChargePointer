using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;
using ChargePointer.Presentation.Models.LocationModel;
using ChargePointer.Services.LocationService;


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
        public List<LocationResponseModel> GetAll()
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
        
        [HttpPatch]
        [Route("{locationId}")]
        public void PatchUpdate([FromRoute]string locationId, [FromBody] PatchLocationRequestModel patchLocationRequestModel)
        {
            try
            {
                _locationService.PatchUpdate(locationId, patchLocationRequestModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        [Route("{locationId}")]
        public void UpdateChargePoints(string locationId, [FromBody] List<ChargePointRequestModel> chargePoints)
        {
            
        }
    }
}