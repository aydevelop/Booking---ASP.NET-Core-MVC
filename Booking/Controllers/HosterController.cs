using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Controllers
{
    public class HosterController : Controller
    {
        static List<Hoster> hosters = new List<Hoster>()
        {
            new Hoster(){ Id=1, FirstName="Robin", LastName="Williams"},
            new Hoster(){ Id=2, FirstName="Ben", LastName="Stiller" },
            new Hoster(){ Id=3, FirstName="Sandra", LastName="Bullock"},
            new Hoster(){ Id=4, FirstName="Jonah", LastName="Hill"}
        };

        public IActionResult Index()
        {
            return View(hosters);
        }

        public ActionResult Details(int id)
        {
            Hoster h = hosters.First(s => s.Id == id);
            return View(h);
        }

        public ActionResult CreateOrEdit(int id)
        {
            var hoster = hosters.FirstOrDefault(s => s.Id == id);
            return View(hoster != null ? hoster : new Hoster());
        }


        [HttpPost]
        public ActionResult Create(Hoster hoster)
        {
            if (!ModelState.IsValid)
            {
                return View(hoster);
            }

            hoster.Id = hosters.Max(s => s.Id) + 1;
            hosters.Add(hoster);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Hoster hoster)
        {
            if (!ModelState.IsValid)
            {
                return View(hoster);
            }

            var item = hosters.First(s => s.Id == hoster.Id);
            item.FirstName = hoster.FirstName;
            item.LastName = hoster.LastName;
            item.State = hoster.State;

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            var hoster = hosters.FirstOrDefault(s => s.Id == id);
            if (hoster == null)
            {
                return NotFound();
            }

            return View(hoster);
        }

        [HttpPost]
        public IActionResult DeleteHoster(int id)
        {
            var hoster = hosters.FirstOrDefault(s => s.Id == id);
            if (hoster == null)
            {
                return NotFound();
            }

            hosters.Remove(hoster);
            return RedirectToAction(nameof(Index));
        }
    }
}
