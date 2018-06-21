using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IJ_w55296;

namespace IJ_w55296.Controllers
{
    public class OrganizacjeTsController : Controller
    {
        private DatabazeFirst_3Entities db = new DatabazeFirst_3Entities();

        // GET: OrganizacjeTs
        public ActionResult Index()
        {
            return View(db.OrganizacjeT.ToList());
        }

        // GET: OrganizacjeTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizacjeT organizacjeT = db.OrganizacjeT.Find(id);
            if (organizacjeT == null)
            {
                return HttpNotFound();
            }
            return View(organizacjeT);
        }

        // GET: OrganizacjeTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizacjeTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizacjaID,Nazwa,KRS,NIP,Wojewodztwo,Powiat,Gmina,Miasto,KodPocztowy,Ulica,ZakresDzialan,Telefon,TelefonKom,Email,AdresWWW,DataZałozenia,DataZawieszenia,DataWznowienia,FormaPrawna,Aktywnosc")] OrganizacjeT organizacjeT)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    db.OrganizacjeT.Add(organizacjeT);
                    db.SaveChanges();
                    return RedirectToAction("Details", "OrganizacjeTs", new { id = organizacjeT.OrganizacjaID}); ;
                }
               
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            
            return View(organizacjeT);
        }

        // GET: OrganizacjeTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizacjeT organizacjeT = db.OrganizacjeT.Find(id);
            if (organizacjeT == null)
            {
                return HttpNotFound();
            }
            return View(organizacjeT);
        }

        // POST: OrganizacjeTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var organizacjeToUpdate = db.OrganizacjeT.Find(id);

            if (TryUpdateModel(organizacjeToUpdate, "",
                new string[] { "Miasto", "KodPocztowy", "Ulica", "Telefon", "TelefonKom", "Email", "AdresWWW", "DataZawieszenia", "DataWznowienia", "Aktywnosc" }))
                {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                    }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(organizacjeToUpdate);
        }

        // GET: OrganizacjeTs/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesErro = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(saveChangesErro.GetValueOrDefault())
            {
                ViewBag.ErrorMassage = "Delete Failed. Try again, and if the problem persist" + "see your system administrator";
            }
            OrganizacjeT organizacjeT = db.OrganizacjeT.Find(id);
            if (organizacjeT == null)
            {
                return HttpNotFound();
            }
            return View(organizacjeT);
        }

        // POST: ZarzadTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                OrganizacjeT organizacjeT = db.OrganizacjeT.Find(id);
                db.OrganizacjeT.Remove(organizacjeT);
                db.SaveChanges();
                
            }
            catch(RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Index");

        }

        // GET: ZarzadTs/Create
        public ActionResult CreateMenagement(int? id)
        {

            PopulateMenagement(id);
            return View();

        }

        
    
        // POST: ZarzadTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMenagement([Bind(Include = "ZarzdID,Nazwisko,Imie,Funkcja,OrganizacjaID")] ZarzadT zarzadT, int? id)
        {
             
            try
            {
                if (ModelState.IsValid)
                {
                    
                    db.ZarzadT.Add(zarzadT);
                    db.SaveChanges();
                    return RedirectToAction("Details", "OrganizacjeTs", new { id = id });
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateMenagement(id);
            ViewBag.OrganizacjaID = new SelectList(db.OrganizacjeT, "OrganizacjaID", "Nazwa");
            return View(zarzadT);
        }

        // GET: ZarzadTs/Edit/5
        public ActionResult EditMenagement(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZarzadT zarzadT = db.ZarzadT.Find(id);
            if (zarzadT == null)
            {
                return HttpNotFound();
            }
            PopulateMenagement(zarzadT.OrganizacjaID);
            return View(zarzadT);
        }



        // POST: ZarzadTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("EditMenagement")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPostMenagement(int? id, ZarzadT zarzadT)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var menagmentToUpdate = db.ZarzadT.Find(id);
            if (TryUpdateModel(menagmentToUpdate, "",
               new string[] { "Nazwisko", "Imie", "Funkcja", "OrganizacjaID" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Details", "OrganizacjeTs", new { id = menagmentToUpdate.OrganizacjaID});
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateMenagement(menagmentToUpdate.OrganizacjaID);
            return View(menagmentToUpdate);
        }

        private void PopulateMenagement(object selectedDepartment = null)
        {
            var departmentsQuery = from d in db.OrganizacjeT
                                   orderby d.Nazwa
                                   select d;
            ViewBag.OrganizacjaID = new SelectList(departmentsQuery, "OrganizacjaID", "Nazwa");
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