using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Booking.Tests
{
    public class BaseControllerTest
    {
        private readonly Mock<DbSet<Location>> _setMock;

        public BaseControllerTest()
        {
            var _locations = new List<Location>
            {
                new Location{Id = 1, Name = "L1", State = LocationState.Active},
                new Location{Id = 2, Name = "L2", State = LocationState.Active},
                new Location{Id = 3, Name = "L3", State = LocationState.Active},
                new Location{Id = 4, Name = "L4", State = LocationState.Active}
            };

            _setMock = new Mock<DbSet<Location>>(_locations);
        }

        [Fact]
        public void IndexReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
        }
    }
}
