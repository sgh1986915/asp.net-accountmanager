using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountManager.Models;

namespace AccountManager.Controllers
{
    public class SubscriptionController : Controller
    {
        private SubscriptionEntities db = new SubscriptionEntities();

        // GET: Subscription
        public ActionResult Index()
        {
            var enterprise = db.Enterprise.Include(e => e.User).Include(e => e.User1);
            return View(enterprise.ToList());
        }

        // GET: Subscription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Enterprise.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // GET: Subscription/Create
        public ActionResult Create()
        {
            ViewBag.OwnerUserId = new SelectList(db.User, "UserId", "UserName");
            ViewBag.ResellerUserId = new SelectList(db.User, "UserId", "UserName");
            return View();
        }

        // POST: Subscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Profile,MaxFemales,Config,Culture,OwnerUserId,SharedFileSystemId,EnterpriseCode,DefaultServerId,NextRenewalDate,MaxWebUsers,MaxRemoteAppUsers,ManagedWebServer,Tier,ConsultantLicenses,DesktopLicenses,MobileLicenses,ServerAndDesktopLicenses,ResellerUserId")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Enterprise.Add(enterprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerUserId = new SelectList(db.User, "UserId", "UserName", enterprise.OwnerUserId);
            ViewBag.ResellerUserId = new SelectList(db.User, "UserId", "UserName", enterprise.ResellerUserId);
            return View(enterprise);
        }

        // GET: Subscription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Enterprise.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerUserId = new SelectList(db.User, "UserId", "UserName", enterprise.OwnerUserId);
            ViewBag.ResellerUserId = new SelectList(db.User, "UserId", "UserName", enterprise.ResellerUserId);
            return View(enterprise);
        }

        // POST: Subscription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Profile,MaxFemales,Config,Culture,OwnerUserId,SharedFileSystemId,EnterpriseCode,DefaultServerId,NextRenewalDate,MaxWebUsers,MaxRemoteAppUsers,ManagedWebServer,Tier,ConsultantLicenses,DesktopLicenses,MobileLicenses,ServerAndDesktopLicenses,ResellerUserId")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enterprise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerUserId = new SelectList(db.User, "UserId", "UserName", enterprise.OwnerUserId);
            ViewBag.ResellerUserId = new SelectList(db.User, "UserId", "UserName", enterprise.ResellerUserId);
            return View(enterprise);
        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Enterprise.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // POST: Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enterprise enterprise = db.Enterprise.Find(id);
            db.Enterprise.Remove(enterprise);
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
