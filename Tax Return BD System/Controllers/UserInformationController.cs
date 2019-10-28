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

using System.Data.SqlClient;
using System.Configuration;

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



        //email

        public ActionResult GetEmailFileById(UserDocument userDocument)
        {

            var userDocuments = from userdocument in db.UserDocuments join file in db.FileDetails on userdocument.DocumentId equals file.DocumentId select new { userdocument.Tax_Year, userdocument.DocumentName, userdocument.Notes };
            return View();

        }

        [HttpPost]
        public ActionResult GetEmailById(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
              //  var userDocuments = from userdocument in db.UserDocuments join file in db.FileDetails on userdocument.DocumentId equals file.DocumentId where userdocument.DocumentId== id select new { userdocument.Tax_Year, userdocument.DocumentName, file.FileName };
               // var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"));
                //UserDocument userDocument = db.UserDocuments.Where(x => x.AirlinesId == id).FirstOrDefault<AirlinesInformation>();
                //db.AirlinesInformations.Remove(AirlinesInformations);
                //db.SaveChanges();
                return Json(new { success = true, message = "Email Send Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }



        public ActionResult GetData()
        {

            List <UserDocument> userdocuments= new List<UserDocument>();
            string cs = ConfigurationManager.ConnectionStrings["TaxDBContext"].ConnectionString;

            string queryString = "select *,(SELECT STRING_AGG(FileName, ', ') FROM filedetails where DocumentId=a.DocumentId)filename from UserDocuments a";
              using (SqlConnection connection =new SqlConnection(cs))
            {
                SqlCommand command =new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserDocument UserDocument = new UserDocument();
                    UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                    UserDocument.DocumentName= reader["DocumentName"].ToString();
                    UserDocument.Notes = reader["Notes"].ToString();
                    UserDocument.Document = reader["filename"].ToString();                   
                    userdocuments.Add(UserDocument);
                }

               
                reader.Close();
            }
            //var userDocuments = from userdocument in db.UserDocuments join file in db.FileDetails on userdocument.DocumentId equals file.DocumentId  select new  {userdocument.Tax_Year,userdocument.DocumentName,file.FileName};
            //var sdf = db.FileDetails.Select(x => x.FileName);
            //var ssss = string.Join(",", sdf);



            //var userDocumentss= from userdocument in db.UserDocuments join file in db.FileDetails on userdocument.DocumentId equals file.DocumentId select new { userdocument.Tax_Year, userdocument.DocumentName, ssss };


            // var userDocuments = from userdocument in db.UserDocuments join file in db.FileDetails on userdocument.DocumentId equals file.DocumentId select new { userdocument.Tax_Year, userdocument.DocumentName, userdocument.Notes, userdocument.DocumentId, file.FileName };

            return Json(new { data = userdocuments }, JsonRequestBehavior.AllowGet);



        }

        [HttpGet]
        public ActionResult Create_Document()
        {
            List<TaxYear> taxlist = db.TaxYears.Where(a => a.Default_Code == true).ToList<TaxYear>();
            TaxYear tax = new TaxYear();
            tax = taxlist.FirstOrDefault();
            string taxyear = tax.Tax_Year;

            ViewBag.Tax_Year = taxyear;
            return View();
        }

        [HttpPost]
        public ActionResult Create_Document(UserDocument userDocument)
        {
           
            if (ModelState.IsValid)
            {

                userDocument.DocumentId = Guid.NewGuid();
                db.UserDocuments.Add(userDocument);
                db.SaveChanges();

                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            Id = Guid.NewGuid(),
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),                          
                            DocumentId= userDocument.DocumentId
                        };
                        fileDetails.Add(fileDetail);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"),fileDetail.Id+ fileDetail.Extension);
                        file.SaveAs(path);

                        db.FileDetails.Add(fileDetail);
                        db.SaveChanges();
                    }
                }
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

            //    userDocument.FileDetails = fileDetails;
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
