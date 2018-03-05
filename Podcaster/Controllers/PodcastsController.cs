using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Podcaster.Models;

namespace Podcaster.Controllers
{
    public class PodcastsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Podcasts
        public ActionResult Index()
        {
            return View(db.Podcasts.ToList());
        }

        // GET: Podcasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return HttpNotFound();
            }
            return View(podcast);
        }

        // GET: Podcasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PodcastTitle,PodcastRss,PodcastImage")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                db.Podcasts.Add(podcast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return HttpNotFound();
            }
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PodcastTitle,PodcastRss,PodcastImage")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podcast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return HttpNotFound();
            }
            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Podcast podcast = db.Podcasts.Find(id);
            db.Podcasts.Remove(podcast);
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
