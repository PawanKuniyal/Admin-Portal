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
    public class StaticPagesManagementController : Controller
    {
        private HelpaEntity db = new HelpaEntity();

        // GET: StaticPagesManagement
        public ActionResult Index()
        {
            return View(db.StaticPages.ToList());
        }

        // GET: StaticPagesManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaticPage staticPage = db.StaticPages.Find(id);
            if (staticPage == null)
            {
                return HttpNotFound();
            }
            return View(staticPage);
        }

        // GET: StaticPagesManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaticPagesManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaticPageId,PageTitle,PageContent,PageType,CreatedDate,UpdatedDate")] StaticPage staticPage)
        {
            if (ModelState.IsValid)
            {
                db.StaticPages.Add(staticPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staticPage);
        }

        // GET: StaticPagesManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            var dataid = db.StaticPages.Single(x => x.StaticPageId == id);
            return View(dataid);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //StaticPage staticPage = db.StaticPages.Find(id);
            //if (staticPage == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(staticPage);
        }

        // POST: StaticPagesManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id,StaticPage collection)
        {
            try
            {
                StaticPage sp = db.StaticPages.Single(x => x.StaticPageId == id);
                sp.PageTitle = collection.PageTitle;
                sp.PageContent = collection.PageContent;
                sp.CreatedDate = collection.CreatedDate;
                //sp.UpdatedDate = collection.UpdatedDate;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(staticPage).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(staticPage);
        }

        // GET: StaticPagesManagement/Delete/5
        public ActionResult Delete(int? id)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaticPage staticPage = db.StaticPages.Find(id);
            db.StaticPages.Remove(staticPage);
            db.SaveChanges();
            if (staticPage == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: StaticPagesManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaticPage staticPage = db.StaticPages.Find(id);
            db.StaticPages.Remove(staticPage);
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
