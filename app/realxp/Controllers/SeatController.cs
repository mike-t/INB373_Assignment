using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using realxp;

namespace realxp.Controllers
{
    public class SeatController : Controller
    {
        private realxpEntities db = new realxpEntities();

        // GET: /Seat/
        public ActionResult Index()
        {
            var seats = db.seats.Include(s => s.camera).Include(s => s.venue);
            return View(seats.ToList());
        }

        // GET: /Seat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seat seat = db.seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // GET: /Seat/Create
        public ActionResult Create()
        {
            ViewBag.cameraID = new SelectList(db.cameras, "cameraID", "camera_brand");
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name");
            return View();
        }

        // POST: /Seat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="seatID,cameraID,venueID,seat_capacity,seat_number,seat_row,seat_section,seat_description,seat_view_image")] seat seat)
        {
            if (ModelState.IsValid)
            {
                db.seats.Add(seat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cameraID = new SelectList(db.cameras, "cameraID", "camera_brand", seat.cameraID);
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", seat.venueID);
            return View(seat);
        }

        // GET: /Seat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seat seat = db.seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            ViewBag.cameraID = new SelectList(db.cameras, "cameraID", "camera_brand", seat.cameraID);
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", seat.venueID);
            return View(seat);
        }

        // POST: /Seat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="seatID,cameraID,venueID,seat_capacity,seat_number,seat_row,seat_section,seat_description,seat_view_image")] seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cameraID = new SelectList(db.cameras, "cameraID", "camera_brand", seat.cameraID);
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", seat.venueID);
            return View(seat);
        }

        // GET: /Seat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seat seat = db.seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // POST: /Seat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            seat seat = db.seats.Find(id);
            db.seats.Remove(seat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
