using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tax_Return_BD_System.Models;

namespace Tax_Return_BD_System.Controllers
{
    public class TaxYearController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaxYear
        public ActionResult Index()
        {
            return View(db.TaxYears.ToList());
        }

        // GET: TaxYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxYear taxYear = db.TaxYears.Find(id);
            if (taxYear == null)
            {
                return HttpNotFound();
            }
            return View(taxYear);
        }

        // GET: TaxYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxYear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaxYearId,Tax_Year,Default_Code")] TaxYear taxYear)
        {
            if (ModelState.IsValid)
            {
                db.TaxYears.Add(taxYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taxYear);
        }

        // GET: TaxYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxYear taxYear = db.TaxYears.Find(id);
            if (taxYear == null)
            {
                return HttpNotFound();
            }
            return View(taxYear);
        }

        // POST: TaxYear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaxYearId,Tax_Year,Default_Code")] TaxYear taxYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taxYear);
        }

        // GET: TaxYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxYear taxYear = db.TaxYears.Find(id);
            if (taxYear == null)
            {
                return HttpNotFound();
            }
            return View(taxYear);
        }

        // POST: TaxYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaxYear taxYear = db.TaxYears.Find(id);
            db.TaxYears.Remove(taxYear);
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
