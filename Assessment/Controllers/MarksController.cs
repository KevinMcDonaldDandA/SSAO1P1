/**
 * 
 * name         :   MarksController.cs
 * author       :   Kevin McDonald
 * email        :   kevin.mcdonald@dundeeandangus.ac.uk
 * version      :   1.0
 * date         :   15th February 2019
 * description  :   Controller class for the Marks Model
 *
 * */

using Assessment.Models;
using Assessment.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assessment.Controllers
{
    public class MarksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Marks
        public ActionResult Index()
        {
            return View(db.Marks.ToList());
        }

        public ActionResult Clear()
        {
            foreach (var mark in db.Marks.ToList())
            {
                db.Marks.Remove(mark);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Marks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marks/Create
        [HttpPost]
        public ActionResult Create(Mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Marks.Add(mark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mark);
        }

        // GET: Marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: Marks/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Total")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mark);
        }

        // GET: Marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            db.Marks.Remove(mark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //  GET: Marks/Summary
        public ActionResult Summary()
        {
            MarkSummary summary = new MarkSummary(db.Marks.ToList());
            return View(summary);
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
//--    End of File --//