using System;
//using DataTables.AspNet.Mvc5;
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
    public class UserInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserInformation
        //public ActionResult Index() 
        //{
        //    return View(db.UserInformations.ToList());
        //}

        //[HttpGet]
        //public ActionResult GetData()
        //{
        //    List<UserInformation> UserInformations = db.UserInformations.ToList<UserInformation>();
        //      return Json(new {data= UserInformations},JsonRequestBehavior.AllowGet);

        //}

        [HttpGet]
        public ActionResult Create_Profile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Profile(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userProfile);
        }




        [HttpGet]
        public ActionResult Create_Document()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Document(UserDocument userDocument)
        {
            if (ModelState.IsValid)
            {
                db.UserDocuments.Add(userDocument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDocument);
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
