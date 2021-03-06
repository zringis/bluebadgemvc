﻿using BlueBadge.Models;
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
            var model = service.GetTechs();

            return View(model);
        }

        //CONNECTED DATABASE
        public ActionResult Create()
        {
            //Here
            var service = CreateTechService();
            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName");
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation");
            ViewBag.LocationId = locationList;
            //to here
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TechCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTechService();

            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName", model.SkillId);
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation", model.LocationId);
            ViewBag.LocationId = locationList;


            if (service.CreateTech(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName} Was Added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{model.FirstName} {model.LastName} Could Not Be Added.");

            

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
            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName");
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation");
            ViewBag.LocationId = locationList;

            var detail = service.GetTechById(id);
            var model =
                new TechEdit
                {
                    TechId = detail.TechId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,


                    LocationId = detail.LocationId,

                    SkillId = detail.SkillId,

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
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName} Was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"{model.FirstName} {model.LastName} Could Not Be Updated.");

            var skillList = new SelectList(service.SkillList(), "SkillId", "SkillName", model.SkillId);
            ViewBag.SkillId = skillList;
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation", model.LocationId);
            ViewBag.LocationId = locationList;

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTechService();
            var model = svc.GetTechById(id);

            return View(model);
        }


        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTechService();

            service.DeleteTech(id);

            TempData["SaveResult"] = "Tech was deleted";

            return RedirectToAction("Index");
        }

    }
}