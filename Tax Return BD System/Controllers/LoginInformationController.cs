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
    public class LoginInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoginInformation
        public ActionResult Index()
        {
            return View(db.LoginInformations.ToList());
        }
        public ActionResult Login(string returnUrl)
        {
            if (returnUrl == "/Account/LogOff" || Session["msg"] == null)
            {
                Session["msg"] = "";
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.msg = Session["msg"].ToString();
                Session.Abandon();
                //auth.SetToken("");
                return View();
            }
            if (returnUrl != null)
            {
                Session["msg"] = "Session Expired";
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.msg = Session["msg"].ToString();
                Session.Abandon();
                //auth.SetToken("");
                return View();
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.msg = Session["msg"].ToString();
                Session.Abandon();
                //auth.SetToken("");
                return View();
            }

        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> DoLoginAsync(LoginViewModel objUser)
        {


            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    //var obj = db.RegistrationInformations.Where(a => a.Email==a.Email && a.Password==a.Password).FirstOrDefault();
                    var obj = db.RegistrationInformations.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();

                    var type = obj.UserType.ToString();

                    if (type == null)
                    {
                        return RedirectToAction("AdminIndex", "Home");
                    }
                    //var password = obj.PasswordHash.ToString();
                    else if (obj != null && type == "Admin")
                    {
                        return RedirectToAction("AdminIndex", "Home");
                    }
                    else if (obj != null && type == "User")
                    {
                        return RedirectToAction("UserIndex", "Home");
                    }
                }
            }
            return View(objUser);
        }
        //    string Email = "";
        //    string Password = "";

        //    //string BaseUrl = auth.GetBaseURL();
        //    try
        //    {
        //        Email = Request["Email"].ToString();
        //        Password = Request["Password"].ToString();

        //        using (var client = new HttpClient())
        //        {

        //            // TODO - Send HTTP requests              
        //           // client.BaseAddress = new Uri(BaseUrl);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            // HTTP POST                
        //            var body = new List<KeyValuePair<string, string>>
        //        {
        //            new KeyValuePair<string, string>("grant_type", "password"),
        //            new KeyValuePair<string, string>("username", Email),
        //            new KeyValuePair<string, string>("password", Password)
        //        };
        //            var content = new FormUrlEncodedContent(body);
        //            HttpResponseMessage response = await client.PostAsync("token", content);
        //            if (response.IsSuccessStatusCode)
        //            {


        //                string responseStream = await response.Content.ReadAsStringAsync();
        //              //  AccessTokenViewModel accessToken = JsonConvert.DeserializeObject<AccessTokenViewModel>(responseStream);
        //               // auth.SetToken(accessToken.access_token);
        //               // string test = auth.GetToken();

        //                //HttpContext.Session["accessToken"] = accessToken.access_token;
        //                //Console.WriteLine(test);
        //                //Console.ReadLine();
        //                //var payloadResponse = _IWebApiClientRepository.GlobalApiCallFunction(null, "GetAccess");
        //                //var list = JsonConvert.DeserializeObject<List<Accesslist>>(payloadResponse.Payload.ToString());
        //                //HttpContext.Session["Page"] = list;
        //                if (returnUrl == null || returnUrl == "/Account/LogOff" || returnUrl == "login")
        //                {
        //                    return RedirectToAction("Index", "Home");
        //                }
        //                //ViewBag.ReturnUrl = BaseUrl + returnUrl;
        //                //return RedirectToAction(returnUrl.ToString());
        //                Session["msg"] = "Login Failed";
        //                return Redirect(returnUrl.ToString());
        //                //return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                string responseStream = await response.Content.ReadAsStringAsync();
        //                //LoginMsg loginMsg = JsonConvert.DeserializeObject<LoginMsg>(responseStream);
        //                //Session["msg"] = loginMsg.error_description;
        //                return RedirectToAction("Login");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Session["msg"] = ex.ToString();
        //        return RedirectToAction("Login");
        //    }

        //    Session["msg"] = "Login Failed";
        //    return RedirectToAction("Login");

        //}

        // GET: LoginInformation/Edit/5

        // GET: LoginInformation/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInformation loginInformation = db.LoginInformations.Find(id);
            if (loginInformation == null)
            {
                return HttpNotFound();
            }
            return View(loginInformation);
        }

        // GET: LoginInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Password,RememberMe")] LoginInformation loginInformation)
        {
            if (ModelState.IsValid)
            {
                db.LoginInformations.Add(loginInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginInformation);
        }
        public ActionResult LogOff()
        {
            Session["msg"] = "";
            //Auth auth = new Auth();
            // AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //auth.DestroyToken();
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }

        // GET: LoginInformation/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInformation loginInformation = db.LoginInformations.Find(id);
            if (loginInformation == null)
            {
                return HttpNotFound();
            }
            return View(loginInformation);
        }

        // POST: LoginInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Password,RememberMe")] LoginInformation loginInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginInformation);
        }

        // GET: LoginInformation/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginInformation loginInformation = db.LoginInformations.Find(id);
            if (loginInformation == null)
            {
                return HttpNotFound();
            }
            return View(loginInformation);
        }

        // POST: LoginInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoginInformation loginInformation = db.LoginInformations.Find(id);
            db.LoginInformations.Remove(loginInformation);
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
