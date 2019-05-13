using BlueBadge.Models;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeMVC.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var service = new LocationServices();
            var model = service.GetLocation();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new LocationServices();

            service.CreateLocation(model);

            return RedirectToAction("Index");
        }
    }
}