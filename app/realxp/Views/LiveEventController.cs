using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using realxp;

namespace realxp.Views
{
    public class LiveEventController : Controller
    {
        private realxpEntities db = new realxpEntities();

        // GET: /LiveEvent/
        public ActionResult Index()
        {
            var liveevents = db.liveevents.Include(l => l.venue);
            return View(liveevents.ToList());
        }

        // GET: /LiveEvent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            liveevent liveevent = db.liveevents.Find(id);
            if (liveevent == null)
            {
                return HttpNotFound();
            }
            return View(liveevent);
        }

        // GET: /LiveEvent/Create
        public ActionResult Create()
        {
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name");
            return View();
        }

        // POST: /LiveEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="liveeventID,venueID,liveevent_start_time,liveevent_end_time,liveevent_name,liveevent_description,liveevent_image")] liveevent liveevent)
        {
            if (ModelState.IsValid)
            {
                db.liveevents.Add(liveevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", liveevent.venueID);
            return View(liveevent);
        }

        // GET: /LiveEvent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            liveevent liveevent = db.liveevents.Find(id);
            if (liveevent == null)
            {
                return HttpNotFound();
            }
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", liveevent.venueID);
            return View(liveevent);
        }

        // POST: /LiveEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="liveeventID,venueID,liveevent_start_time,liveevent_end_time,liveevent_name,liveevent_description,liveevent_image")] liveevent liveevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liveevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", liveevent.venueID);
            return View(liveevent);
        }

        // GET: /LiveEvent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            liveevent liveevent = db.liveevents.Find(id);
            if (liveevent == null)
            {
                return HttpNotFound();
            }
            return View(liveevent);
        }

        // POST: /LiveEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            liveevent liveevent = db.liveevents.Find(id);
            db.liveevents.Remove(liveevent);
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
