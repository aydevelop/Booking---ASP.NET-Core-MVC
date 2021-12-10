using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Tests
{
    public class BaseControllerTest
    {
        private Task<List<Location>> GetData()
        {
            List<Location> _locations = new List<Location>
            {
                new Location{Id = 1, Name = "L1", State = LocationState.Active},
                new Location{Id = 2, Name = "L2", State = LocationState.Active},
                new Location{Id = 3, Name = "L3", State = LocationState.Active},
                new Location{Id = 4, Name = "L4", State = LocationState.Active}
            };

            return Task.FromResult(_locations);
        }

        [Fact]
        public async Task IndexReturnsListOfLocationAsync()
        {
            // Arrange
            var mock = new Mock<ILocationRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetData());
            var controller = new BaseController<Location>(mock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Location>>(viewResult.Model);
            Assert.Equal((await GetData()).Count, model.Count);
        }

        [Fact]
        public async void AddLocationReturnsWithModelAsync()
        {
            // Arrange
            var mock = new Mock<ILocationRepository>();
            var controller = new BaseController<Location>(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            Location newLocation = new Location();

            // Act
            var result = await controller.Create(newLocation);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(newLocation, viewResult?.Model);
        }

        [Fact]
        public async void AddLocationUserReturnsRedirectAsync()
        {
            // Arrange
            var mock = new Mock<ILocationRepository>();
            var controller = new BaseController<Location>(mock.Object);
            var newLocation = new Location() { Name = "London" };

            // Act
            var result = await controller.Create(newLocation);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async void GetLocationReturnsBadRequestAsync()
        {
            // Arrange
            var mock = new Mock<ILocationRepository>();
            var controller = new BaseController<Location>(mock.Object);

            // Act
            var result = await controller.Details(null);

            // Arrange
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void GetLocationWithId0ReturnsNotFoundAsync()
        {
            // Arrange
            int testId = 0;
            var mock = new Mock<ILocationRepository>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(async () => await Task.FromResult(null as Location));
            var controller = new BaseController<Location>(mock.Object);

            // Act
            var result = await controller.Details(testId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetLocationReturnsViewResultWithLocationAsync()
        {
            // Arrange
            int testId = 1;
            Location location = (await GetData()).FirstOrDefault(p => p.Id == testId);

            var mock = new Mock<ILocationRepository>();
            mock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(async () => await Task.FromResult(location));
            var controller = new BaseController<Location>(mock.Object);

            // Act
            var result = await controller.Details(testId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Location>(viewResult.ViewData.Model);
            Assert.Equal("L1", model.Name);
            Assert.Equal(testId, model.Id);
        }
    }
}
