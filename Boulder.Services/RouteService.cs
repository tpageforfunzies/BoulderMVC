using Boulder.Models;
using Boulder.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Boulder.Services
{
    public class RouteService
    {

        private readonly Guid _userId;

        //constructor for the service, takes a GUID from
        //controller when created
        public RouteService(Guid userID)
        {
            _userId = userID;
        }

        public IEnumerable<RouteListItem> GetRoutes()
        {
            using (var db = new DbContext())
            {
                var query =
                    db
                        .Routes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new RouteListItem
                                {
                                    RouteId = e.RouteId,
                                    RouteGrade = e.RouteGrade,
                                    RouteName = e.RouteName,
                                    RouteNote = e.RouteNote,
                                    DateSent = e.DateSent
            }
                        );
                return query.ToArray();

            }
        }

        public RouteDetail GetRouteById(int routeId)
        {
            using(var db = new DbContext())
            {
                var route =
                    db
                        .Routes
                        .Single(e => e.RouteId == routeId && e.UserId == _userId);

                return
                    new RouteDetail
                    {
                        RouteId = route.RouteId,
                        RouteGrade = route.RouteGrade,
                        RouteName = route.RouteName,
                        RouteNote = route.RouteNote,
                        DateSent = route.DateSent,
                    };
            }
        }

        public bool CreateRoute(RouteCreate model)
        {
            var route =
                new Route()
                {
                    UserId = _userId,
                    RouteName = model.RouteName,
                    RouteGrade = model.RouteGrade,
                    RouteNote = model.RouteNote,
                    DateSent = DateTime.Now
                };
            using (var db = new DbContext())
            {
                db.Routes.Add(route);
                return db.SaveChanges() == 1;
            }
        }

        public bool UpdateRoute(RouteEdit model)
        {
            using (var db = new DbContext())
            {
                var route =
                    db
                        .Routes
                        .Single(e => e.RouteId == model.RouteId && e.UserId == _userId);

                route.RouteName = model.RouteName;
                route.RouteGrade = model.RouteGrade;
                route.RouteNote = model.RouteNote;
                route.DateSent = model.DateSent;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteRoute(int routeId)
        {
            using (var db = new DbContext())
            {
                var route =
                    db
                        .Routes
                        .Single(e => e.RouteId == routeId && e.UserId == _userId);
                db.Routes.Remove(route);
                return db.SaveChanges() == 1;
            }
        }
    }
}
