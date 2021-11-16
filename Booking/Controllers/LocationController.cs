using Booking.Models;
using System.Collections.Generic;

namespace Booking.Controllers
{
    public class LocationController
    {
        static List<Location> partments = new List<Location>()
        {
            new Location(){ Id=1, Name="місто Сокаль" },
            new Location(){ Id=2, Name="місто Бібрка" },
            new Location(){ Id=3, Name="місто Куп'янськ" },
            new Location(){ Id=4, Name="місто Моспине" }
        };
    }
}
