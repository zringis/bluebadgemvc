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
    }
}