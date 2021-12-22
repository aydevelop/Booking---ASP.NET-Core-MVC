using Booking.BLL.Contracts;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using System;

namespace Booking.BLL.Jobs
{
    public class DraftApartmentJob
    {
        public static string Interval = "* */1 * * *";
        private readonly IRepositories _repositories;

        public DraftApartmentJob(IRepositories repositories)
        {
            _repositories = repositories;
        }

        public void Run()
        {
            var rents = _repositories.Rents.GetWithInclude(new[] { "Apartment" }).Result;
            DateTime now = DateTime.Now;

            for (int i = 0; i < rents.Count; i++)
            {
                Rent rent = rents[i];
                if (rent.State == RentState.Approved && rent.EndDate.Date == now.Date)
                {
                    Apartment apartment = rent.Apartment;
                    apartment.State = ApartmentState.Draft;
                    _repositories.Apartments.Update(apartment).Wait();
                }
                else if (rent.Apartment.State == ApartmentState.Draft && rent.EndDate.Date < now.Date)
                {
                    Apartment apartment = rent.Apartment;
                    apartment.State = ApartmentState.Active;
                    _repositories.Apartments.Update(apartment).Wait();
                }
            }
        }
    }
}
