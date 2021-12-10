using Booking.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Booking.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void HandleErrorViewDataMessage()
        {
            // Arrange
            int code = 404;
            HomeController controller = new HomeController();

            // Act
            ViewResult result = Assert.IsType<ViewResult>(controller.HandleError(code));

            // Assert
            Assert.NotNull(result);
            Assert.Equal($"Error occurred with ErrorCode: {code}", result?.ViewData["Message"]);
        }

        [Fact]
        public void ExceptionHandlerViewDataMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = Assert.IsType<ViewResult>(controller.ExceptionHandler());

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result?.ViewData["Message"]?.ToString().Contains("Exception occurred with RequestId"));
        }

    }
}
