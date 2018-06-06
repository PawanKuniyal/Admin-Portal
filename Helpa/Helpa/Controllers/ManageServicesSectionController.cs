using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Helpa;

namespace Helpa.Controllers
{
    public class ManageServicesSectionController : Controller
    {
        private HelpaEntity db = new HelpaEntity();

        // GET: ManageServicesSection
        public ActionResult Index()
        {
            var item = db.Services.ToList();
            
            return View(item.ToList());
        }

        // GET: ManageServicesSection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            //if (service.Status == true)
            //    service.StatusValue = "Enable";
            //else
            //    service.StatusValue = "Disbale";

            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: ManageServicesSection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageServicesSection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,ServiceName,Status,RowStatus,CreatedDate,UpdatedDate")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: ManageServicesSection/Edit/5
        public ActionResult Edit(int? id)
        {
            var dataid = db.Services.Single(x => x.ServiceId==id);
            return View(dataid);
            
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Service service = db.Services.Find(id);
            ////if (service.Status == true)
            ////    service.StatusValue = "Enable";
            ////else
            ////    service.StatusValue = "Disbale";

            //if (service == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(service);
        }

        // POST: ManageServicesSection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Service collection)
        {
            try
            {
                Service serobj = db.Services.Single(x => x.ServiceId == id);
                serobj.ServiceName = collection.ServiceName;
                serobj.CreatedDate = collection.CreatedDate;
                //serobj.UpdatedDate = collection.UpdatedDate;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(service).State = EntityState.Modified;                
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(service);
        }

        // GET: ManageServicesSection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            if (service == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: ManageServicesSection/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
        public ActionResult Status(int id)
        {
            Service item = new Helpa.Service();
            item = db.Services.Find(id);
            if (item.Status == false)
            {
                item.Status = true;
            }
            else
            {
                item.Status = false;
            }
            db.Services.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
