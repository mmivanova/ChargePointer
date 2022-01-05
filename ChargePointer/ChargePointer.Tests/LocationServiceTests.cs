using AutoMapper;
using ChargePointer.Core.RequestModels;
using ChargePointer.Core.Services.ChargePointService;
using ChargePointer.Core.Services.LocationService;
using ChargePointer.Infrastructure.Domain.Entities;
using ChargePointer.Infrastructure.Repositories.LocationRepository;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChargePointer.Tests
{
    public class LocationServiceTests
    {
        private readonly LocationService _systemUnderTest;
        private readonly Mock<ILocationRepository> _locationRepoMock = new();
        private readonly Mock<IChargePointService> _chargePointServiceMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public LocationServiceTests()
        {
            _systemUnderTest = new LocationService(_locationRepoMock.Object,
                _chargePointServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Get_ShouldReturnLocation_WhenLocationExists()
        {
            var locationId = "testId";
            var testLocation = TestLocation(locationId);
            _locationRepoMock.Setup(p => p.Get(locationId)).Returns(testLocation);
           
            var location = _systemUnderTest.Get(locationId);
            
            Assert.Equal(location, testLocation);
        }

        [Fact]
        public void Get_ShouldReturnNull_WhenLocationDoesNotExists()
        { 
            var locationId = "testId";
            _locationRepoMock.Setup(p => p.Get(locationId));
            
            var location = _systemUnderTest.Get(locationId);

            Assert.Null(location);
        }

        [Fact]
        public void GetAll_ShouldReturnAllExistingLocations()
        {
            var testLocations = MultipleLocations();
            _locationRepoMock.Setup(lr => lr.GetAll()).Returns(testLocations);
            
            var locations = _systemUnderTest.GetAll();
            
            Assert.Equal(testLocations, locations);
        }

        [Fact]
        public void Create_ShouldCallRepositoryJustOnce()
        {
            var locationId = "createTest";
            var location = TestLocation(locationId);
            _locationRepoMock.Setup(lr => lr.Create(location));
            
            _systemUnderTest.Create(location);
            
            _locationRepoMock.Verify(lr => lr.Create(location), Times.Once);
        }

        [Fact]
        public void PatchUpdate_ShouldUpdateOnlyPassedParameters_OnExistingLocation()
        {
            var locationId = "patchUpdateId";
            var originalLocation = TestLocation(locationId);
            var patchRequestModel = new PatchLocationRequestModel
            {
                LocationId = locationId,
                Name = "PatchName",
                Address = "PatchAddress"
            };
            var mockedLocation = originalLocation;
            mockedLocation.Name = patchRequestModel.Name;
            mockedLocation.Address = patchRequestModel.Address;

            _mapperMock.Setup(m => m.Map(patchRequestModel, originalLocation)).Returns(mockedLocation);
            _locationRepoMock.Setup(lr => lr.PatchUpdate(mockedLocation));
          
            _systemUnderTest.PatchUpdate(locationId, patchRequestModel);
          
            Assert.Equal(originalLocation, mockedLocation);
        }


        [Fact]
        public void PatchUpdate_ThrowsAnException_WhenUrlLocationIdAndRequestBodyLocationIdDoesNotMatch()
        {
            var locationId = "patchUpdateId";
            var originalLocation = TestLocation(locationId);
            var patchRequestModel = new PatchLocationRequestModel
            {
                LocationId = "anotherId",
                Name = "PatchName",
                Address = "PatchAddress"
            };
            var mockedLocation = originalLocation;
            mockedLocation.Name = patchRequestModel.Name;
            mockedLocation.Address = patchRequestModel.Address;

            _mapperMock.Setup(m => m.Map(patchRequestModel, originalLocation)).Returns(mockedLocation);
            _locationRepoMock.Setup(lr => lr.PatchUpdate(mockedLocation));


            Assert.Throws<ArgumentException>(() => _systemUnderTest.PatchUpdate(locationId, patchRequestModel));
        }


        [Fact]
        public void UpdateLocationChargePoints_ShouldCallCreateNewChargePointsForLocationOnce()
        {
            var locationId = "testId";
            var chargePointRequestModel = new ChargePointRequestModel
            {
                LocationId=locationId,
                ChargePoints = new List<ChargePoint>
                {
                    new ChargePoint
                    {
                        ChargePointId = "first",
                        Status = "TestStatus",
                        FloorLevel = "1",
                        LastUpdated = DateTime.Today
                    },
                    new ChargePoint
                    {
                        ChargePointId = "second",
                        Status = "TestStatus2",
                        FloorLevel = "2",
                        LastUpdated = DateTime.Today
                    },
                    new ChargePoint
                    {
                        ChargePointId = "third",
                        Status = "TestStatus3",
                        FloorLevel = "3",
                        LastUpdated = DateTime.Today
                    }
                }
            };
            _chargePointServiceMock.Setup(cps => cps.CreateNewChargePointsForLocation(chargePointRequestModel));

            _systemUnderTest.UpdateLocationChargePoints(locationId, chargePointRequestModel);

            _chargePointServiceMock.Verify(cps => cps.CreateNewChargePointsForLocation(chargePointRequestModel), Times.Once);
        }


        [Fact]
        public void UpdateLocationChargePoints_ShouldCallUpdateChargePointsOnce()
        {
            var locationId = "testId";
            var chargePointRequestModel = GetChargePointRequestModel(locationId);
            _chargePointServiceMock.Setup(cps => cps.UpdateChargePoints(chargePointRequestModel));

            _systemUnderTest.UpdateLocationChargePoints(locationId, chargePointRequestModel);

            _chargePointServiceMock.Verify(cps => cps.UpdateChargePoints(chargePointRequestModel), Times.Once);
        }


        [Fact]
        public void UpdateLocationChargePoints_ThrowsAnException_WhenUrlLocationIdAndRequestBodyLocationIdDoesNotMatch()
        {
            var locationId = "testId";
            var differentId = "differentId";
            var chargePointRequestModel = GetChargePointRequestModel(differentId);

            
            Assert.Throws<ArgumentException>(() => _systemUnderTest.UpdateLocationChargePoints(locationId, chargePointRequestModel));
        }

        private ChargePointRequestModel GetChargePointRequestModel(string locationId)
        {
            return new ChargePointRequestModel
            {
                LocationId = locationId,
                ChargePoints = new List<ChargePoint>
                {
                    new ChargePoint
                    {
                        ChargePointId = "first",
                        Status = "TestStatus",
                        FloorLevel = "1",
                        LastUpdated = DateTime.Today
                    },
                    new ChargePoint
                    {
                        ChargePointId = "second",
                        Status = "TestStatus2",
                        FloorLevel = "2",
                        LastUpdated = DateTime.Today
                    },
                    new ChargePoint
                    {
                        ChargePointId = "third",
                        Status = "TestStatus3",
                        FloorLevel = "3",
                        LastUpdated = DateTime.Today
                    }
                }
            };
        }

        private Location TestLocation(string locationId)
        {
            return new Location
            {
                LocationId = locationId,
                Type = "TestType",
                Name = "TestName",
                Address = "TestAddress",
                City = "TestCity",
                Country = "TestCountry",
                PostalCode = "TestPC",
                LastUpdated = DateTime.Today
            };
        }

        private List<Location> MultipleLocations()
        {
            return new List<Location>
            {
                new Location {
                        LocationId = "testId1",
                        Type = "TestType1",
                        Name = "TestName1",
                        Address = "TestAddress1",
                        City = "TestCity1",
                        Country = "TestCountry1",
                        PostalCode = "TestPC1",
                        LastUpdated = DateTime.Today },

                new Location {
                        LocationId = "testId2",
                        Type = "TestType2",
                        Name = "TestName2",
                        Address = "TestAddress2",
                        City = "TestCity2",
                        Country = "TestCountry2",
                        PostalCode = "TestPC2",
                        LastUpdated = DateTime.Today },

                new Location {
                        LocationId = "testId3",
                        Type = "TestType3",
                        Name = "TestName3",
                        Address = "TestAddress3",
                        City = "TestCity3",
                        Country = "TestCountry3",
                        PostalCode = "TestPC3",
                        LastUpdated = DateTime.Today },
            };
        }
    }
}