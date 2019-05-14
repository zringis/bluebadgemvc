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
    public class CustomerController : Controller
    {
        // GET: Customer
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomers();

            return View(model);
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        public ActionResult Create()
        {
            var service = CreateCustomerService();
            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation");
            ViewBag.LocationId = locationList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation", model.LocationId);
            ViewBag.LocationId = locationList;

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Customer could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();

            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation");
            ViewBag.LocationId = locationList;

            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    CompanyName = detail.CompanyName,

                    LocationId = detail.LocationId
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer could not be updated.");

            var locationList = new SelectList(service.LocationList(), "LocationId", "FullLocation", model.LocationId);
            ViewBag.LocationId = locationList;

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Customer was deleted";

            return RedirectToAction("Index");
        }
    }
}