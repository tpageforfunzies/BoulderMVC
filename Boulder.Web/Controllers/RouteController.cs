﻿using Boulder.Models;
using Boulder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boulder.Web.Controllers
{
    public class RouteController : Controller
    {
        //creates the service and passes in the parsed 
        //GUID for the UserId in the models/entities
        private RouteService CreateRouteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RouteService(userId);
            return service;
        }

        // GET: Route
        public ActionResult Index()
        {
            var service = CreateRouteService();
            var model = service.GetRoutes();
            return View(model);
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RouteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRouteService();
            
            if (service.CreateRoute(model))
            {
                TempData["CreateResult"] = "Route added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Route could not be added.");
            return View(model);
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Route/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Route/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}