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
    public class AccessInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccessListInformation
        //public ActionResult Index()
        //{
        //    return View(db.AccessLists.ToList());
        //}

        // GET: AccessListInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    if (accessListInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accessListInformation);
        //}

        public ActionResult Menu_Create()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            return View();
        }

        // POST: AccessListInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Menu_Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuItem);
        }
        // GET: AccessListInformation/Create
        public ActionResult SubMenu_Create()
        {
            ViewBag.MenuId = new SelectList(db.MenuItems, "MenuId", "MenuName");
            return View();
        }

        // POST: AccessListInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubMenu_Create(SubMenuItem subMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.SubMenuItems.Add(subMenuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subMenuItem);
        }

        // GET: AccessListInformation/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    if (accessListInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accessListInformation);
        //}

        //// POST: AccessListInformation/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "AccessId,AccessName,BaseModule,Controller,Action")] AccessListInformation accessListInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(accessListInformation).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(accessListInformation);
        //}

        //// GET: AccessListInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    if (accessListInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accessListInformation);
        //}

        //// POST: AccessListInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    db.AccessLists.Remove(accessListInformation);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
