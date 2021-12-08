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


            var features = new List<Feature>
            {
                new Feature { Name="Bar", State=FeatureState.Active },
                new Feature { Name="WiFi", State=FeatureState.Active },
                new Feature { Name="Parking", State=FeatureState.Inactive },
                new Feature { Name="Heating", State=FeatureState.Active }
            };
            context.Features.AddRange(features);
            context.SaveChanges();


            var explorers = new List<Explorer>
            {
                new Explorer{FirstName="Tim", LastName="Flynn", Email="tim@mail.com", Birthday=DateTime.Now.AddYears(-20), State=ExplorerState.Active},
                new Explorer{FirstName="Michael", LastName="Hughey", Email="michael@mail.com", Birthday=DateTime.Now.AddYears(-30), State=ExplorerState.Banned, DateFromState=DateTime.Now.AddDays(3)},
                new Explorer{FirstName="Stephen", LastName="Sikes", Email="stephen@mail.com", Birthday=DateTime.Now.AddYears(-40), State=ExplorerState.Active}
            };
            context.Explorers.AddRange(explorers);
            context.SaveChanges();


            var apartments = new List<Apartment>
            {
                new Apartment {
                    Name="Mountain Residence", Address="Chaikovskogo 127",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Features=new List<Feature>
                    {
                        context.Features.OrderBy(q=>Guid.NewGuid()).First(),
                        context.Features.OrderBy(q=>Guid.NewGuid()).First(),
                    }
                },
                new Apartment {
                    Name="Cities Gallery", Address="Tomashivs'koho 4",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Features=new List<Feature>
                    {
                        context.Features.OrderBy(q=>Guid.NewGuid()).First(),
                        context.Features.OrderBy(q=>Guid.NewGuid()).First(),
                    }
                },
                new Apartment {
                    Name="Opera Passage", Address="Baseina Street 77a",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Features=new List<Feature>
                    {
                        context.Features.OrderBy(q=>Guid.NewGuid()).First(),
                        context.Features.OrderBy(q=>Guid.NewGuid()).First(),
                    }
                }
            };

            context.Apartments.AddRange(apartments);
            context.SaveChanges();

            var rents = new List<Rent>
            {
                new Rent {
                    ExplorerId=context.Explorers.Where(q=>q.State==ExplorerState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    ApartmentId=context.Apartments.Where(q=>q.State==ApartmentState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    StartDate=DateTime.Now.AddDays(2), EndDate=DateTime.Now.AddDays(4), State = RentState.Approved
                },
                 new Rent {
                    ExplorerId=context.Explorers.Where(q=>q.State==ExplorerState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    ApartmentId=context.Apartments.Where(q=>q.State==ApartmentState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    StartDate=DateTime.Now.AddDays(3), EndDate=DateTime.Now.AddDays(2), State = RentState.Requested
                },
                new Rent {
                    ExplorerId=context.Explorers.Where(q=>q.State==ExplorerState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    ApartmentId=context.Apartments.Where(q=>q.State==ApartmentState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    StartDate=DateTime.Now.AddDays(4), EndDate=DateTime.Now.AddDays(1), State = RentState.Approved
                },
                new Rent {
                    ExplorerId=context.Explorers.Where(q=>q.State==ExplorerState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    ApartmentId=context.Apartments.Where(q=>q.State==ApartmentState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    StartDate=DateTime.Now.AddDays(1), EndDate=DateTime.Now.AddDays(2), State = RentState.Requested
                },
            };

            context.Rents.AddRange(rents);
            context.SaveChanges();

        }
    }
}
