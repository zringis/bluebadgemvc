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
    public class SkillController : Controller
    {
        // GET: Skill
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService(userId);
            var model = service.GetSkills();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSkillService();

            if (service.CreateSkill(model))
            {
                TempData["SaveResult"] = "Skill was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Skill could not be created.");

            return View(model);
        }

        private SkillService CreateSkillService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService(userId);
            return service;
        }
    }
}