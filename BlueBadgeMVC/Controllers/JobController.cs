using BlueBadge.Models;
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
            var model = new JobListItem[0];
            return View(model);
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}