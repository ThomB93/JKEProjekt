using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using JKEMVC.Models;

namespace JKEMVC.Controllers
{
    public class UdstillingsmodelsController : Controller
    {
        private UdstillingsmodelDBContext db = new UdstillingsmodelDBContext();

        // GET: Udstillingsmodels
        public ActionResult Index()
        {
            return View(db.Udstillingsmodels.ToList());
        }
        

        // GET: Udstillingsmodels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udstillingsmodel udstillingsmodel = db.Udstillingsmodels.Find(id);
            if (udstillingsmodel == null)
            {
                return HttpNotFound();
            }
            return View(udstillingsmodel);
        }

        // GET: Udstillingsmodels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Udstillingsmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Udstillingsmodel udstillingsmodel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                //upload image
                if (image != null && image.ContentLength > 0)
                {
                    try
                    {
                        //Here, I create a custom name for uploaded image
                        string file_name = udstillingsmodel.titel + Path.GetExtension(image.FileName);

                        string path = Path.Combine(Server.MapPath("~/Content/Images"), file_name);
                        image.SaveAs(path);

                        // image_path is nvarchar type db column. We save the name of the file in that column. 
                        udstillingsmodel.billedeSti = "~/Content/Images" + "/" + file_name;
                    }
                    catch (Exception ex)
                    {

                    }
                }


                db.Udstillingsmodels.Add(udstillingsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(udstillingsmodel);
        }

        // GET: Udstillingsmodels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udstillingsmodel udstillingsmodel = db.Udstillingsmodels.Find(id);
            if (udstillingsmodel == null)
            {
                return HttpNotFound();
            }
            return View(udstillingsmodel);
        }

        // POST: Udstillingsmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,titel,beskrivelse,billedeSti")] Udstillingsmodel udstillingsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(udstillingsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(udstillingsmodel);
        }

        // GET: Udstillingsmodels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Udstillingsmodel udstillingsmodel = db.Udstillingsmodels.Find(id);
            if (udstillingsmodel == null)
            {
                return HttpNotFound();
            }
            return View(udstillingsmodel);
        }

        // POST: Udstillingsmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Udstillingsmodel udstillingsmodel = db.Udstillingsmodels.Find(id);
            db.Udstillingsmodels.Remove(udstillingsmodel);
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
