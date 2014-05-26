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
    public class VenueReviewController : Controller
    {
        private realxpEntities db = new realxpEntities();

        // GET: /VenueReview/
        public ActionResult Index()
        {
            var venue_review = db.venue_review.Include(v => v.user).Include(v => v.venue);
            return View(venue_review.ToList());
        }

        // GET: /VenueReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue_review venue_review = db.venue_review.Find(id);
            if (venue_review == null)
            {
                return HttpNotFound();
            }
            return View(venue_review);
        }

        // GET: /VenueReview/Create
        public ActionResult Create()
        {
            ViewBag.userID = new SelectList(db.users, "userID", "user_email");
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name");
            return View();
        }

        // POST: /VenueReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="venue_reviewID,venueID,userID,venue_review_review,venue_review_rating")] venue_review venue_review)
        {
            if (ModelState.IsValid)
            {
                db.venue_review.Add(venue_review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userID = new SelectList(db.users, "userID", "user_email", venue_review.userID);
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", venue_review.venueID);
            return View(venue_review);
        }

        // GET: /VenueReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue_review venue_review = db.venue_review.Find(id);
            if (venue_review == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.users, "userID", "user_email", venue_review.userID);
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", venue_review.venueID);
            return View(venue_review);
        }

        // POST: /VenueReview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="venue_reviewID,venueID,userID,venue_review_review,venue_review_rating")] venue_review venue_review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue_review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.users, "userID", "user_email", venue_review.userID);
            ViewBag.venueID = new SelectList(db.venues, "venueID", "venue_name", venue_review.venueID);
            return View(venue_review);
        }

        // GET: /VenueReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venue_review venue_review = db.venue_review.Find(id);
            if (venue_review == null)
            {
                return HttpNotFound();
            }
            return View(venue_review);
        }

        // POST: /VenueReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            venue_review venue_review = db.venue_review.Find(id);
            db.venue_review.Remove(venue_review);
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
