using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpa.Controllers
{
    public class ManageIDVerificationController : Controller
    {
        // GET: ManageIDVerification
        HelpaEntity dc = new Helpa.HelpaEntity();
        public ActionResult Index()
        {
          
            var data = (from d in dc.Documents join h in dc.Helpers on d.HelperId equals h.HelperId select d).ToList();


            // var data = dc.AspNetUsers.ToList();
            //foreach (var dd in data)
            //{
            //    if (dd.RowStatus == "0")
            //    {
            //        dd.ButtonText = "Deactive";
            //        dd.ButtonColor = "Orange";
            //    }
            //    else 
            //    {
            //        {
            //            dd.ButtonText = "Active"; 
            //            dd.ButtonColor = "Green";
            //        }
            //    }
               
            //}
            return View(data);
            //return RedirectToAction("Index", "ManageIDVerification");
        }
    }
}