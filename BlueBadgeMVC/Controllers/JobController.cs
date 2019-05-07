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
            var model = service.GetNotes();

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Job was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }
        
    }
}