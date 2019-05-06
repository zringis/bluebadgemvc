using BlueBadge.Models;
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
            var model = new SkillListItem[0];
            return View(model);
        }
    }
}