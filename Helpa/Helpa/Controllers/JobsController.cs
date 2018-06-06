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
    public class JobsController : Controller
    {
        private HelpaEntity db = new HelpaEntity();

        // GET: Jobs
        public ActionResult Index()
        {
            //if (Session["UserName"] != null)
            //{
                var item = db.Jobs.Include(j => j.JobLocation).Include(j => j.JobPrice).Include(j => j.JobTime);

                return View(item.ToList());
            //}
            //else {

            //    return RedirectToAction("Login", "Account");
            //}
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        //public ActionResult Create()
        //{
        //    ViewBag.LocationId = new SelectList(db.JobLocations, "JobLocationId", "JobLocationName");
        //    ViewBag.PriceId = new SelectList(db.JobPrices, "JobPriceId", "RowStatus");
        //    ViewBag.TimeId = new SelectList(db.JobTimes, "JobTimeId", "JobTimeId");
        //    return View();
        //}

        //// POST: Jobs/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
       
        //public ActionResult Create([Bind(Include = "JobId,CreatedUserId,JobTiltle,JobDescription,JobType,HelperType,LocationId,TimeId,PriceId,Status,RowStatus,CreatedDate,ExpiryDate,UpdatedDate")] Job job)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Jobs.Add(job);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.LocationId = new SelectList(db.JobLocations, "JobLocationId", "JobLocationName", job.LocationId);
        //    ViewBag.PriceId = new SelectList(db.JobPrices, "JobPriceId", "RowStatus", job.PriceId);
        //    ViewBag.TimeId = new SelectList(db.JobTimes, "JobTimeId", "JobTimeId", job.TimeId);
        //    return View(job);
        //}

        // GET: Jobs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Job job = db.Jobs.Find(id);
        //    if (job == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.LocationId = new SelectList(db.JobLocations, "JobLocationId", "JobLocationName", job.LocationId);
        //    ViewBag.PriceId = new SelectList(db.JobPrices, "JobPriceId", "RowStatus", job.PriceId);
        //    ViewBag.TimeId = new SelectList(db.JobTimes, "JobTimeId", "JobTimeId", job.TimeId);
        //    return View(job);
        //}

        //// POST: Jobs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
       
        //public ActionResult Edit([Bind(Include = "JobId,CreatedUserId,JobTiltle,JobDescription,JobType,HelperType,LocationId,TimeId,PriceId,Status,RowStatus,CreatedDate,ExpiryDate,UpdatedDate")] Job job)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(job).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.LocationId = new SelectList(db.JobLocations, "JobLocationId", "JobLocationName", job.LocationId);
        //    ViewBag.PriceId = new SelectList(db.JobPrices, "JobPriceId", "RowStatus", job.PriceId);
        //    ViewBag.TimeId = new SelectList(db.JobTimes, "JobTimeId", "JobTimeId", job.TimeId);
        //    return View(job);
        //}

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            if (job == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
            Job item = new Helpa.Job();
            item = db.Jobs.Find(id);
            if(item.Status==false)
            {
                item.Status = true;
            }
            else
            {
                item.Status = false;
            }
            db.Jobs.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
