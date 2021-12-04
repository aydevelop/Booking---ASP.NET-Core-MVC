using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.DAL
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (creator.Exists()) { return; }
            context.Database.Migrate();

            var locations = new List<Location>
            {
                new Location { Name="Kyiv", State=LocationState.Active },
                new Location { Name="Lviv", State=LocationState.Active },
                new Location { Name="Odesa", State=LocationState.Active },
                new Location { Name="Poltava", State=LocationState.Active },
                new Location { Name="Cherkasy", State=LocationState.Inactive }
            };
            context.Locations.AddRange(locations);
            context.SaveChanges();


            var hosters = new List<Hoster>
            {
                new Hoster { FirstName="Devonte", LastName="Klein", State=HosterState.Active},
                new Hoster { FirstName="Anika", LastName="Halvorson", State=HosterState.Active},
                new Hoster { FirstName="Kale", LastName="Bernhard", State=HosterState.Active},
                new Hoster { FirstName="Nyasia", LastName="Langworth", State=HosterState.Active},
                new Hoster { FirstName="Timmy", LastName="Nader", State=HosterState.Inactive}
            };
            context.Hosters.AddRange(hosters);
            context.SaveChanges();


            var apartments = new List<Apartment>
            {
                new Apartment {
                    Name="Mountain Residence", Address="Chaikovskogo 127",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster = context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location= context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                },
                new Apartment {
                    Name="Cities Galleryl", Address="Tomashivs'koho 4",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster = context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location= context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                },
                new Apartment {
                    Name="Opera Passage", Address="Baseina Street 77a",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster = context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location= context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                }
            };

            context.Apartments.AddRange(apartments);
            context.SaveChanges();
        }
    }
}
