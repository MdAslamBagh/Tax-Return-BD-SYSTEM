using System;
//using DataTables.AspNet.Mvc5;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        public ActionResult Create_Profile_Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Profile_Admin(UserProfile userProfile)
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


        public ActionResult GetData()
        {
            List<UserDocument> userDocuments = db.UserDocuments.ToList<UserDocument>();
            return Json(new { data = userDocuments }, JsonRequestBehavior.AllowGet);

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
                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            //Id = Guid.NewGuid()
                            //Id = Guid.NewGuid();
                            //Id = fileDetail.Id;


                        };
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"),fileDetail.Id+ fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                userDocument.FileDetails = fileDetails;
                db.UserDocuments.Add(userDocument);
                db.SaveChanges();
                return RedirectToAction("Create_Document");
            }

            return View(userDocument);
            //if (ModelState.IsValid)
            //{
            //    db.UserDocuments.Add(userDocument);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(userDocument);
        }


        [HttpGet]
        public ActionResult Create_Document_Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_Document_Admin(UserDocument userDocument)
        {

            if (ModelState.IsValid)
            {
                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];


                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            //Id = Guid.NewGuid()
                            //Id = Guid.NewGuid();
                            //Id = fileDetail.Id;


                        };
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                userDocument.FileDetails = fileDetails;
                db.UserDocuments.Add(userDocument);
                db.SaveChanges();
                return RedirectToAction("Create_Document");
            }

            return View(userDocument);
            //if (ModelState.IsValid)
            //{
            //    db.UserDocuments.Add(userDocument);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(userDocument);
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
