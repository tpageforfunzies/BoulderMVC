using Boulder.Models;
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
            var stats = service.GetStats();
            ViewData.Add("Stats", stats);
            return View(model);
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            var service = CreateRouteService();
            var model = service.GetRouteById(id);
            return View(model);
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
            var service = CreateRouteService();
            var detail = service.GetRouteById(id);
            var model =
                new RouteEdit
                {
                    RouteId = detail.RouteId,
                    RouteGrade = detail.RouteGrade,
                    RouteName = detail.RouteName,
                    RouteNote = detail.RouteNote,
                    DateSent = detail.DateSent,
                };

            return View(model);
        }

        // POST: Route/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RouteEdit model)
        {


            var service = CreateRouteService();

            if (service.UpdateRoute(model))
            {
                TempData["SaveResult"] = "Your route was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your route could not be updated.");
            return View(model);

        }

        // GET: Route/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateRouteService();
            var model = service.GetRouteById(id);

            return View(model);
        }

        // POST: Route/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoute(int id)
        {
            try
            {
                var service = CreateRouteService();
                service.DeleteRoute(id);

                TempData["SaveResult"] = "Route Deleted";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
