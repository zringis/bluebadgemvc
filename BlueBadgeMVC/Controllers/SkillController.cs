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
            var service = new SkillService();
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
                TempData["SaveResult"] = $"{model.SkillName} Was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{model.SkillName} Could Not Be Created.");

            return View(model);
        }

        private SkillService CreateSkillService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService();
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateSkillService();
            var model = svc.GetSkillById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSkillService();
            var detail = service.GetSkillById(id);
            var model =
                new SkillEdit
                {
                    SkillId = detail.SkillId,
                    SkillName = detail.SkillName,
                    SkillDescription = detail.SkillDescription
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SkillEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SkillId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSkillService();

            if (service.UpdateSkill(model))
            {
                TempData["SaveResult"] = $"{model.SkillName} Was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"{model.SkillName} Could Not Be Updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSkillService();
            var model = svc.GetSkillById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSkillService();

            service.DeleteSkill(id);

            TempData["SaveResult"] = "Skill was deleted";

            return RedirectToAction("Index");
        }
    }

    
}