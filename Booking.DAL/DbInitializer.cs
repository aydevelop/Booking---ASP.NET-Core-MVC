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
        static AppDbContext context;

        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            context = serviceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureDeleted();
            //var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //if (creator.Exists()) { return; }

            context.Database.Migrate();
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var admin = new IdentityUser
            {
                UserName = "admin01",
                Email = "admin01@mail.com",
            };

            var hoster = new Hoster
            {
                FirstName = "Jermey",
                LastName = "Langosh",
                UserName = "hoster01",
                Email = "hoster01@mail.com",
                PasswordHash = passwordHasher.HashPassword(null, "Pa$$w0rd")
            };

            var explorer = new Explorer
            {
                FirstName = "Bobbie",
                LastName = "Howe",
                UserName = "explorer01",
                Email = "explorer01@mail.com",
                PasswordHash = passwordHasher.HashPassword(null, "Pa$$w0rd"),
                State = ExplorerState.Active,
                //DateFromState = DateTime.Now.AddDays(4)
            };

            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("hoster"));
            await roleManager.CreateAsync(new IdentityRole("explorer"));

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await context.Explorers.AddAsync(explorer);
            await context.Hosters.AddAsync(hoster);

            await userManager.AddToRoleAsync(admin, "admin");
            await userManager.AddToRoleAsync(hoster, "hoster");
            await userManager.AddToRoleAsync(explorer, "explorer");

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
                    Hoster=GetRandomHoster(),
                    HosterId=Guid.Parse(hoster.Id),
                    Location=GetRandomLocation(),
                },
                new Apartment {
                    Name="Cities Gallery", Address="Tomashivs'koho 4",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=hoster,
                    HosterId=Guid.Parse(hoster.Id),
                    Location=GetRandomLocation()
                },
                new Apartment {
                    Name="Opera Passage", Address="Avtozavodskaya 77a",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=hoster,
                    HosterId=Guid.Parse(hoster.Id),
                    Location=GetRandomLocation()
                },
                new Apartment {
                    Name="Barra Family Resort", Address="Volkova 302",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=hoster,
                    HosterId=Guid.Parse(hoster.Id),
                    Location=GetRandomLocation()
                },
                new Apartment {
                    Name="Allurapart Мalahyt", Address="Bogdanovskaya 67b",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=hoster,
                    HosterId=Guid.Parse(hoster.Id),
                    Location=GetRandomLocation()
                },
                new Apartment {
                    Name="City Rooms", Address="Rishelievska 7",
                    AvgScore=5, MaxDurationInDays=7, State=ApartmentState.Active,
                    Hoster=hoster,
                    HosterId=Guid.Parse(hoster.Id),
                    Location=GetRandomLocation()
                },
            };

            context.Apartments.AddRange(apartments);
            await context.SaveChangesAsync();

            foreach (Apartment item in context.Apartments)
            {
                var arrFeatures = context.Features.Where(q => q.State == FeatureState.Active).ToList();
                arrFeatures.RemoveAt(new Random().Next(0, arrFeatures.Count));

                foreach (var feature in arrFeatures)
                {
                    context.ApartmentFeature.Add(new ApartmentFeature()
                    {
                        Apartment = item,
                        Feature = feature,
                    });
                }
            }
            await context.SaveChangesAsync();

            var rents = new List<Rent>
            {
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(1), EndDate=DateTime.Now.AddDays(2), State=RentState.Requested
                },
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(11), EndDate=DateTime.Now.AddDays(2), State=RentState.Approved
                },
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(3), EndDate=DateTime.Now.AddDays(2), State=RentState.Approved
                },
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(7), EndDate=DateTime.Now.AddDays(2), State=RentState.Rejected
                },
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(-13), EndDate=DateTime.Now.AddDays(-5), State=RentState.Completed
                },
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(9), EndDate=DateTime.Now.AddDays(2), State=RentState.Inactive
                },
                new Rent {
                    Explorer = explorer,
                    ExplorerId = Guid.Parse(explorer.Id),
                    Apartment = GetRandomApartment(),
                    StartDate = DateTime.Now.AddDays(-1), EndDate=DateTime.Now, State=RentState.Approved
                },

            };

            context.Rents.AddRange(rents);
            await context.SaveChangesAsync();

            var complaints = new List<Complaint>();
            for (int i = 0; i < 5; i++)
            {
                Complaint complaint = new Complaint();
                Explorer cExplorer = GetRandomExplorer();
                Hoster cHoster = GetRandomHoster();

                complaint.Explorer = cExplorer;
                complaint.ExplorerId = Guid.Parse(cExplorer.Id);

                complaint.Hoster = cHoster;
                complaint.HosterId = Guid.Parse(cHoster.Id);

                complaint.Text = "Smoked in the apartment";
                complaints.Add(complaint);
            }

            context.Complaints.AddRange(complaints);
            await context.SaveChangesAsync();


            if (context.Rents.Count() > 0)
            {
                foreach (var item in context.Apartments)
                {
                    var rates = new List<Rate>();
                    for (int i = 0; i < 5; i++)
                    {
                        Rate rate = new Rate();
                        rate.Apartment = item;
                        rate.Rent = GetRandomRent();
                        rate.Value = new Random().Next(1, 6);
                        rates.Add(rate);
                    }
                    context.Rates.AddRange(rates);
                }
            }

            await context.SaveChangesAsync();

            context.Rents.Add(new Rent
            {
                Explorer = explorer,
                ExplorerId = Guid.Parse(explorer.Id),
                Apartment = GetRandomApartment(),
                StartDate = DateTime.Now.AddDays(-11),
                EndDate = DateTime.Now.AddDays(-5),
                State = RentState.Completed
            });

            await context.SaveChangesAsync();
        }

        static Rent GetRandomRent()
        {
            return context
                .Rents.Where(q => q.State == RentState.Completed)
                .OrderBy(q => Guid.NewGuid()).First();
        }

        static Explorer GetRandomExplorer()
        {
            return context
                .Explorers.Where(q => q.State == ExplorerState.Active)
                .OrderBy(q => Guid.NewGuid()).First();
        }

        static Apartment GetRandomApartment()
        {
            return context
                .Apartments.Where(q => q.State == ApartmentState.Active)
                .OrderBy(q => Guid.NewGuid()).First();
        }

        static Hoster GetRandomHoster()
        {
            return context
                .Hosters.Where(q => q.State == HosterState.Active)
                .OrderBy(q => Guid.NewGuid()).First();
        }

        static Location GetRandomLocation()
        {
            return context
                .Locations.Where(q => q.State == LocationState.Active)
                .OrderBy(q => Guid.NewGuid()).First();
        }
    }
}
