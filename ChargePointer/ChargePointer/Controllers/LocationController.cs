using System;
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

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        
        [HttpGet]
        public Location Get(string id)
        {
            var location = _locationService.Get(id);
            return location;
        }

        [HttpPost]
        public void Create([FromBody] LocationRequestModel locationRequestModel)
        {
            var location = new Location
            {
                LocationId = Guid.NewGuid().ToString(),
                Address = locationRequestModel.Address,
                City = locationRequestModel.City,
                Country = locationRequestModel.Country,
                LastUpdated = locationRequestModel.LastUpdated,
                PostalCode = locationRequestModel.PostalCode,
                Name = locationRequestModel.Name,
                Type = locationRequestModel.Type.ToString()
            };
            _locationService.Create(location);
        }
        
    }
}