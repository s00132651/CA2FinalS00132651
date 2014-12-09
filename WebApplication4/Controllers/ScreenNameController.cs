using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ScreenNameController : Controller
    {
        private CinemaDB db = new CinemaDB();

        //
        // GET: /ScreenName/

        public ActionResult Index()
        {
            var screennames = db.ScreenNames.Include(s => s.Movie).Include(s => s.Actor);
            return View(screennames.ToList());
        }

        //
        // GET: /ScreenName/Details/5

        public ActionResult Details(int id = 0)
        {
            ScreenNames screennames = db.ScreenNames.Find(id);
            if (screennames == null)
            {
                return HttpNotFound();
            }
            return View(screennames);
        }

        //
        // GET: /ScreenName/Create

        public PartialViewResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "Name");
            return PartialView("_Create");
        }

        //
        // POST: /ScreenName/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScreenNames screennames)
        {
            if (ModelState.IsValid)
            {
                db.ScreenNames.Add(screennames);
                 db.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = screennames.MovieId });
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", screennames.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "Name", screennames.ActorId);
            return View(screennames);
        }

        //
        // GET: /ScreenName/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ScreenNames screennames = db.ScreenNames.Find(id);
            if (screennames == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", screennames.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "Name", screennames.ActorId);
            return View(screennames);
        }

        //
        // POST: /ScreenName/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScreenNames screennames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screennames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", screennames.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "Name", screennames.ActorId);
            return View(screennames);
        }

        //
        // GET: /ScreenName/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ScreenNames screennames = db.ScreenNames.Find(id);
            if (screennames == null)
            {
                return HttpNotFound();
            }
            return View(screennames);
        }

        //
        // POST: /ScreenName/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScreenNames screennames = db.ScreenNames.Find(id);
            db.ScreenNames.Remove(screennames);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}