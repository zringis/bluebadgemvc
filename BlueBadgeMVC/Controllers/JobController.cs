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
    }
}