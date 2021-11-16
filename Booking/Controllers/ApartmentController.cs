using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Controllers
{
    public class ApartmentController : Controller
    {
        static List<Apartment> apartments = new List<Apartment>()
        {
            new Apartment(){ Id=1, Name="Apartment 830", HosterId=1, LocationId=1, Address="Street 01, House 01", AvgScore=5, MaxDurationInDays = 10},
            new Apartment(){ Id=1, Name="Apartment 214", HosterId=2, LocationId=2, Address="Street 02, House 02", AvgScore=5, MaxDurationInDays = 10},
            new Apartment(){ Id=1, Name="Apartment 734", HosterId=3, LocationId=3, Address="Street 03, House 03", AvgScore=5, MaxDurationInDays = 10},
            new Apartment(){ Id=1, Name="Apartment 127", HosterId=4, LocationId=5, Address="Street 03, House 05", AvgScore=5, MaxDurationInDays = 10},
        };

        public ActionResult Index()
        {
            return View(apartments);
        }

        public ActionResult Details(int id)
        {
            Apartment apartment = apartments.FirstOrDefault(s => s.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View();
        }

        public ActionResult CreateOrEdit(int id)
        {
            var apartment = apartments.FirstOrDefault(s => s.Id == id);
            return View(apartment != null ? apartment : new Apartment());
        }

        [HttpPost]
        public ActionResult Create(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return View(apartment);
            }

            apartment.Id = apartments.Max(s => s.Id) + 1;
            apartments.Add(apartment);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return View(apartment);
            }

            var item = apartments.First(s => s.Id == apartment.Id);
            item.Name = apartment.Name;
            item.Address = apartment.Address;
            item.MaxDurationInDays = apartment.MaxDurationInDays;

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var hoster = apartments.FirstOrDefault(s => s.Id == id);
            if (hoster == null)
            {
                return NotFound();
            }

            return View(hoster);
        }

        [HttpPost]
        public IActionResult DeleteApartment(int id)
        {
            var apartment = apartments.FirstOrDefault(s => s.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            apartments.Remove(apartment);
            return RedirectToAction(nameof(Index));
        }
    }
}
