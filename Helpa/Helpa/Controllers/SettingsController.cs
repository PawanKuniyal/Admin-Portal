using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpa.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        HelpaEntity he = new HelpaEntity();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Update()
        {
            AspNetUser Obj = new AspNetUser();
            return View(Obj);
        }
        [HttpPost]
        public ActionResult Update(AspNetUser objAspNetUser)
        {
            AspNetUser Obj = new AspNetUser();
            if (Session["UserName"] != null)
            {
                string Id = Session["UserName"].ToString();
                Obj = he.AspNetUsers.Where(x => x.UserName == Id).FirstOrDefault();
                Obj.Email = objAspNetUser.Email;
                Obj.UserName = objAspNetUser.UserName;
                he.AspNetUsers.Attach(Obj);
                he.Entry(Obj).State = EntityState.Modified;
                he.SaveChanges();
                Session.Remove("UserName");
                return View(Obj);
            }
            else {
              return  RedirectToAction("Login", "Account");
            }
        }
    }
}