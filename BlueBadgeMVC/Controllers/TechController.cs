using BlueBadge.Models;
using BlueBadge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeMVC.Controllers
{
    public class TechController : Controller
    {
        // GET: Tech
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateTechService();
            var model = service.GetNotes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TechCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTechService();

            if (service.CreateTech(model))
            {
                TempData["SaveResult"] = "Your tech was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Tech could not be added.");

            return View(model);
        }

        private TechService CreateTechService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TechService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTechService();
            var model = svc.GetTechById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTechService();
            var detail = service.GetTechById(id);
            var model =
                new TechEdit
                {
                    TechId = detail.TechId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Location = detail.Location,
                    HourlyRate = detail.HourlyRate,
                    WeekendRate = detail.WeekendRate,
                    AfterHoursRate = detail.AfterHoursRate,
                    HolidayRate = detail.HolidayRate,
                    EmergencySameDayRate = detail.EmergencySameDayRate,
                    EmergencyNextDayRate = detail.EmergencyNextDayRate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TechEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TechId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTechService();

            if (service.UpdateTech(model))
            {
                TempData["SaveResult"] = "Tech was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Tech could not be updated.");
            return View(model);
        }

    }
}