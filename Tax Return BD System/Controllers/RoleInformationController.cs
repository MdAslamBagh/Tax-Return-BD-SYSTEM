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
    public class RoleInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoleInformation
        public ActionResult Index()
        {
            return View(db.RoleInformations.ToList());
        }

        // GET: RoleInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleInformation roleInformation = db.RoleInformations.Find(id);
            if (roleInformation == null)
            {
                return HttpNotFound();
            }
            return View(roleInformation);
        }

        // GET: RoleInformation/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: RoleInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "RoleId,Name")] RoleInformation roleInformation)
        {
            if (ModelState.IsValid)
            {
                db.RoleInformations.Add(roleInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleInformation);
        }

        // GET: RoleInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleInformation roleInformation = db.RoleInformations.Find(id);
            if (roleInformation == null)
            {
                return HttpNotFound();
            }
            return View(roleInformation);
        }

        // POST: RoleInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,Name")] RoleInformation roleInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleInformation);
        }

        // GET: RoleInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleInformation roleInformation = db.RoleInformations.Find(id);
            if (roleInformation == null)
            {
                return HttpNotFound();
            }
            return View(roleInformation);
        }

        // POST: RoleInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleInformation roleInformation = db.RoleInformations.Find(id);
            db.RoleInformations.Remove(roleInformation);
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
