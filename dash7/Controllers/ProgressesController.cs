﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dash7;

namespace dash7.Controllers
{
    public class ProgressesController : Controller
    {
        private HomeEntities db = new HomeEntities();

        // GET: Progresses
        public ActionResult Index()
        {
            return View(db.Progresses.ToList());
        }
        public ActionResult TeachersIndex()
        {

 
            return View(db.Progresses.ToList());
        }

        // GET: Progresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progress progress = db.Progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // GET: Progresses/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Progresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bar1,Bar2,Bar3,Bar4,IdeaId")] Progress progress)
        {
            if (ModelState.IsValid)
            {
                ViewBag.MyViewBag = progress.IdeaId;
                db.Progresses.Add(progress);
                db.SaveChanges();              
                return RedirectToAction("TeachersIndex","Progresses",);
            }

            return View(progress);
        }

        // GET: Progresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progress progress = db.Progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // POST: Progresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bar1,Bar2,Bar3,Bar4")] Progress progress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(progress);
        }

        // GET: Progresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progress progress = db.Progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // POST: Progresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Progress progress = db.Progresses.Find(id);
            db.Progresses.Remove(progress);
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
