using Booking.BLL.Contracts;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using System;
using System.Threading.Tasks;

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

        public async Task Run()
        {
            var rents = await _repositories.Rents.GetWithInclude(new[] { "Apartment" });
            DateTime now = DateTime.Now;

            for (int i = 0; i < rents.Count; i++)
            {
                Rent rent = rents[i];
                if (rent.State == RentState.Approved && rent.EndDate.Date == now.Date)
                {
                    Apartment apartment = rent.Apartment;
                    apartment.State = ApartmentState.Draft;
                    await _repositories.Apartments.Update(apartment);

                    Rent rentUpdate = await _repositories.Rents.GetById(rent.Id);
                    rentUpdate.State = RentState.Completed;
                    await _repositories.Rents.Update(rentUpdate);
                }
                else if (rent.Apartment.State == ApartmentState.Draft && rent.EndDate.Date < now.Date)
                {
                    Apartment apartment = rent.Apartment;
                    apartment.State = ApartmentState.Active;
                    await _repositories.Apartments.Update(apartment);
                }
            }
        }
    }
}
