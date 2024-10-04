using FlightBoard.Business;
using FlightBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightBoard.Controllers
{
    public class FlightController : Controller
    {
        private FlightBusiness flightBusiness = new FlightBusiness();

        // GET: Flight
        public ActionResult Index()
        {
            var flights = flightBusiness.GetAllFlights();
            return View(flights);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FlightInfo flight)
        {
            if (ModelState.IsValid)
            {
                flightBusiness.AddFlight(flight);
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var flight = flightBusiness.GetAllFlights().Find(f => f.FlightId == id);
            return View(flight);
        }

        [HttpPost]
        public ActionResult Edit(FlightInfo flight)
        {
            if (ModelState.IsValid)
            {
                flightBusiness.EditFlight(flight);
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var flight = flightBusiness.GetAllFlights().Find(f => f.FlightId == id);
            return View(flight);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            flightBusiness.RemoveFlight(id);
            return RedirectToAction("Index");
        }
    }
}