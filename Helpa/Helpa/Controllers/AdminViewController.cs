using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpa.Models;
using System.Data.Entity;

namespace Helpa.Controllers
{
    public class AdminViewController : Controller
    {
        // GET: AdminView
        public ActionResult AdminView()
        {
            HelpaEntity obj = new HelpaEntity();
            List<AspNetUser> data=  obj.AspNetUsers.ToList();
            return View();
        }
        [HttpGet]
        public JsonResult Search(string Search)
        {
            Search = "Omaar";
            HelpaEntity obj = new HelpaEntity();
            AspNetUser data = new AspNetUser();
            data.Email = obj.AspNetUsers.Where(x=>x.UserName.ToLower().Contains(Search)).Select(x=>x.Email).ToList().FirstOrDefault();
          return  Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Grid(string Search)
        {

          //  Search = "omaar";
            HelpaEntity obj = new HelpaEntity();
            List<AspNetUser> data = new List<AspNetUser>();
            if (string.IsNullOrEmpty(Search))
            {
                data = obj.AspNetUsers.ToList();
            }
            else {
                data = obj.AspNetUsers.Where(x => x.UserName.ToLower().Contains(Search)).ToList();

            }
            return View(data);
        }
        public ActionResult Delete(int Id)
        {
            HelpaEntity obj = new Helpa.HelpaEntity();
            AspNetUser Asp= new AspNetUser();
            var Data = obj.AspNetUsers.Where(x => x.Id == Id).FirstOrDefault();
            obj.AspNetUsers.Remove(Data);
            return RedirectToAction("index");
        }
        //[HttpPost]
        //public ActionResult AdminView(string adminview)
        //{
        //    HelpaEntity obj = new HelpaEntity();
        //    return View(obj.AspNetUsers(adminview));
        //}
    }
}