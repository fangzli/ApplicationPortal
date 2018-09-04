using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationPortal.Models;

namespace ApplicationPortal.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Email,Phone")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.ID = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                application.Status = "NoResume";
                application.Notes = "";
                application.ResumeName = "";
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Upload", application);
            }

            return View(application);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(string Name, string Email, string Phone, string ResumeName)
        //{
        //    Application application = new Application(Name, Email, Phone, "", "", ResumeName);
        //    if (ModelState.IsValid)
        //    {
        //        db.Applications.Add(application);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(application);
        //}

        // GET: Applications/Create
        [HttpGet]
        public ActionResult Upload(Application application)
        {
            return View(application);
        }

        // POST: Resume upload
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string [] urlList = Request.Path.Split('/');
            int id = int.Parse(urlList.Last());
            Application application = db.Applications.Find(id);
            try
            {
                if (file.ContentLength > 0)
                {
                    
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    ViewBag.Message = "File Uploaded Successfully!!";

                    // Update database
                    application.ResumeName = _FileName;
                    application.Status = "Pending";
                    db.Entry(application).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.Message = "Empty file";
                    return View(application);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ViewBag.Message = "File upload failed!!";
                return View(application);
            }
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Phone,Status,Notes,ResumeName")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
