using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ChargePointer.Domain.Entities;
using ChargePointer.Presentation.Models.ChargePointModel;
using ChargePointer.Presentation.Models.LocationModel;
using ChargePointer.Services.ChargePointService;
using ChargePointer.Services.LocationService;


namespace ChargePointer.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService, IChargePointService chargePointService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<LocationResponseModel>> GetAll()
        {
            try
            {
                var locations = _locationService
                                .GetAll()
                                .Select(_mapper.Map<LocationResponseModel>)
                                .ToList();

                return new OkObjectResult(locations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BadRequestObjectResult(e.Message);
            }

        }

        [HttpGet]
        [Route("{locationId}")]
        public ActionResult<LocationResponseModel> Get([FromRoute] string locationId)
        {
            try
            {
                var location = _locationService.Get(locationId);
                var responseModel = _mapper.Map<LocationResponseModel>(location);
                return new OkObjectResult(responseModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] LocationRequestModel locationRequestModel)
        {
            try
            {
                var location = _mapper.Map<Location>(locationRequestModel);
                _locationService.Create(location);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BadRequestObjectResult(e.Message);
            }
            return new OkResult();
        }

        [HttpPatch]
        [Route("{locationId}")]
        public IActionResult PatchUpdate([FromRoute] string locationId, [FromBody] PatchLocationRequestModel patchLocationRequestModel)
        {
            try
            {
                _locationService.PatchUpdate(locationId, patchLocationRequestModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BadRequestObjectResult(e.Message);
            }
            return new OkResult();
        }

        [HttpPut]
        [Route("{locationId}")]
        public IActionResult UpdateChargePoints([FromRoute] string locationId, [FromBody] ChargePointRequestModel chargePointRequestModel)
        {
            try
            {
                _locationService.UpdateLocationChargePoints(locationId, chargePointRequestModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BadRequestObjectResult(e.Message);
            }
            return new OkResult();
        }
    }
}