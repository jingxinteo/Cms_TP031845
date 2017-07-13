using MLCMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MLCMS.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        public ActionResult index()
        {
            List < Shipment > shipments = new List<Shipment>();
            using (myModelContainer context = new myModelContainer())
            {
                shipments = context.Shipments.ToList();
            }
            return View(shipments);
        }

        public ActionResult NewShipment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewShipment(NewShipmentViewModel svm)
        {
            using (myModelContainer context = new myModelContainer())
            {
                var shipment = new Shipment();
                shipment.Weight = svm.Weight;
                shipment.Origin = svm.Origin;
                shipment.Destination = svm.Destination;
                shipment.ShippingType = svm.ShippingType;
                shipment.ShippingDate = svm.ShippingDate;
                shipment.ArrivalDate = svm.ArrivalDate;
                shipment.Status = "In progressing";

                context.Shipments.Add(shipment);
                context.SaveChanges();
            }   
            return RedirectToAction("Index");
        }

        public ActionResult UpdateShipment(int id)
        {
            var shipment = new Shipment();
            UpdateShipmentViewModel usvm = new UpdateShipmentViewModel();

            using (myModelContainer context = new myModelContainer())
            {
                shipment = context.Shipments.Where(b => b.ShipId == id).FirstOrDefault();
                usvm.ShipId = shipment.ShipId;
                usvm.Weight = shipment.Weight;
                usvm.Origin = shipment.Origin;
                usvm.Destination = shipment.Destination;
                usvm.ShippingType = shipment.ShippingType;
                usvm.ShippingDate = shipment.ShippingDate;
                usvm.ArrivalDate = shipment.ArrivalDate;
                usvm.Status = shipment.Status;
            }
            return View(usvm);
        }

        [HttpPost]
        public ActionResult UpdateShipment(UpdateShipmentViewModel ship)
        {
            using (myModelContainer context = new myModelContainer())
            {
                var shipment = context.Shipments.Single(e => e.ShipId == ship.ShipId);
                shipment.ShipId = ship.ShipId;
                shipment.Weight = ship.Weight;
                shipment.Origin = ship.Origin;
                shipment.Destination = ship.Destination;
                shipment.ShippingType = ship.ShippingType;
                shipment.ShippingDate = ship.ShippingDate;
                shipment.ArrivalDate = ship.ArrivalDate;
                shipment.Status = ship.Status;
                context.SaveChanges();
              }
            return RedirectToAction("Index");
        }
    }
}