using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IJ_w55296;
using PagedList;


namespace IJ_w55296.Controllers
{
    public class ZarzadTsController : Controller
    {
        private DatabazeFirst_3Entities db = new DatabazeFirst_3Entities();

        // GET: OrganizacjeTs
        public ActionResult Index()
        {
            return View(db.ZarzadT.ToList());
        }


        public ActionResult Delete(int? id, bool? saveChangesErro = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesErro.GetValueOrDefault())
            {
                ViewBag.ErrorMassage = "Delete Failed. Try again, and if the problem persist" + "see your system administrator";
            }
            ZarzadT zarzadT = db.ZarzadT.Find(id);
            if (zarzadT == null)
            {
                return HttpNotFound();
            }
            return View(zarzadT);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
               ZarzadT zarzadT = db.ZarzadT.Find(id);
                db.ZarzadT.Remove(zarzadT);
                db.SaveChanges();

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
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
