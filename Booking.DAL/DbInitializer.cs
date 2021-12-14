using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.DAL
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureDeleted();
            //var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //if (creator.Exists()) { return; }

            context.Database.Migrate();
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var admin = new User
            {
                UserName = "admin01",
                Email = "admin01@mail.com"
            };

            var hoster = new User
            {
                UserName = "hoster01",
                Email = "hoster01@mail.com"
            };

            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("hoster"));
            await roleManager.CreateAsync(new IdentityRole("client"));

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.CreateAsync(hoster, "Pa$$w0rd");
            await userManager.AddToRoleAsync(admin, "admin");
            await userManager.AddToRoleAsync(admin, "hoster");

            var locations = new List<Location>
            {
                new Location { Name="Lviv", State=LocationState.Active },
                new Location { Name="Odesa", State=LocationState.Active },
                new Location { Name="Poltava", State=LocationState.Active },
                new Location { Name="Cherkasy", State=LocationState.Inactive }
            };
            context.Locations.AddRange(locations);
            await context.SaveChangesAsync();


            var hosters = new List<Hoster>
            {
                new Hoster { FirstName="Devonte", LastName="Klein", State=HosterState.Active},
                new Hoster { FirstName="Anika", LastName="Halvorson", State=HosterState.Active},
                new Hoster { FirstName="Kale", LastName="Bernhard", State=HosterState.Active},
                new Hoster { FirstName="Nyasia", LastName="Langworth", State=HosterState.Active},
                new Hoster { FirstName="Timmy", LastName="Nader", State=HosterState.Inactive}
            };
            context.Hosters.AddRange(hosters);
            await context.SaveChangesAsync();


            var features = new List<Feature>
            {
                new Feature { Name="Bar", State=FeatureState.Active },
                new Feature { Name="WiFi", State=FeatureState.Active },
                new Feature { Name="Parking", State=FeatureState.Inactive },
                new Feature { Name="Heating", State=FeatureState.Active }
            };
            context.Features.AddRange(features);
            await context.SaveChangesAsync();


            var explorers = new List<Explorer>
            {
                new Explorer{FirstName="Tim", LastName="Flynn", Email="tim@mail.com", Birthday=DateTime.Now.AddYears(-20), State=ExplorerState.Active},
                new Explorer{FirstName="Michael", LastName="Hughey", Email="michael@mail.com", Birthday=DateTime.Now.AddYears(-30), State=ExplorerState.Banned, DateFromState=DateTime.Now.AddDays(3)},
                new Explorer{FirstName="Stephen", LastName="Sikes", Email="stephen@mail.com", Birthday=DateTime.Now.AddYears(-40), State=ExplorerState.Active}
            };
            context.Explorers.AddRange(explorers);
            await context.SaveChangesAsync();


            var apartments = new List<Apartment>
            {
                new Apartment {
                    Name="Mountain Residence", Address="Chaikovskogo 127",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                },
                new Apartment {
                    Name="Cities Gallery", Address="Tomashivs'koho 4",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First()
                },
                new Apartment {
                    Name="Opera Passage", Address="Baseina Street 77a",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First()
                },
                new Apartment {
                    Name="Opera Passage2", Address="Baseina Street 7a",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First()
                },
                new Apartment {
                    Name="Opera Passage3", Address="Baseina Street 277a",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=context.Hosters.Where(q=>q.State == HosterState.Active).OrderBy(q=>Guid.NewGuid()).First(),
                    Location=context.Locations.Where(q=>q.State == LocationState.Active).OrderBy(q=>Guid.NewGuid()).First()
                }
            };

            context.Apartments.AddRange(apartments);
            await context.SaveChangesAsync();

            foreach (Apartment item in context.Apartments)
            {
                context.ApartmentFeature.Add(new ApartmentFeature()
                {
                    ApartmentId = item.Id,
                    FeatureId = context.Features.Where(q => q.State == FeatureState.Active)
                    .OrderBy(q => Guid.NewGuid()).First().Id,
                });
            }
            await context.SaveChangesAsync();

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
                new Rent {
                    ExplorerId=context.Explorers.Where(q=>q.State==ExplorerState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    ApartmentId=context.Apartments.Where(q=>q.State==ApartmentState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    StartDate=DateTime.Now.AddDays(1), EndDate=DateTime.Now.AddDays(2), State = RentState.Rejected
                },
                new Rent {
                    ExplorerId=context.Explorers.Where(q=>q.State==ExplorerState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    ApartmentId=context.Apartments.Where(q=>q.State==ApartmentState.Active).OrderBy(q=>Guid.NewGuid()).First().Id,
                    StartDate=DateTime.Now.AddDays(1), EndDate=DateTime.Now.AddDays(2), State = RentState.Inactive
                },
            };

            context.Rents.AddRange(rents);
            await context.SaveChangesAsync();
        }
    }
}
