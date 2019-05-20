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
    public class JobController : Controller
    {
        // GET: Job
        [Authorize]
         public ActionResult Index()
        {
            var service = CreateJobService();
            var model = service.GetJobs();

            return View(model);
        }

        private JobService CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            return service;
        }

        // GET
        public ActionResult Create()
        {
            var service = CreateJobService();
            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName");
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation");
            ViewBag.LocationId = locationList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobService();

            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName", model.SkillId);
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation", model.LocationId);
            ViewBag.LocationId = locationList;

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = $"{model.CompanyName}'s Job Was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{model.CompanyName}'s Job Could Not Be Created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateJobService();
            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName");
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation");
            ViewBag.LocationId = locationList;

            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    CompanyName = detail.CompanyName,
                    JobId = detail.JobId,
                    SkillId = detail.SkillId,
                    JobDescription = detail.JobDescription,
                    LocationId = detail.LocationId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JobId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateJobService();

            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "Job was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Job could not be updated.");

            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName", model.SkillId);
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation", model.LocationId);
            ViewBag.LocationId = locationList;

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJob(int id)
        {
            var service = CreateJobService();

            service.DeleteJob(id);

            TempData["SaveResult"] = "Job was deleted";

            return RedirectToAction("Index");
        }

    }
}