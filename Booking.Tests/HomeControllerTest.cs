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
            ViewResult result = controller.HandleError(code) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal($"Error occurred with ErrorCode: {code}", result?.ViewData["Message"]);
        }
    }
}
