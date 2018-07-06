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

        // GET: ZarzadTs
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.OrSortParm = sortOrder == "Organizations" ? "or_desc" : "Organizations";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var menagement = from s in db.ZarzadT
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                menagement = menagement.Where(s => s.Nazwisko.Contains(searchString)
                                        || s.Imie.Contains(searchString)
                                        || s.OrganizacjeT.Nazwa.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    menagement = menagement.OrderByDescending(s => s.Nazwisko);
                    break;
                case "Organizations":
                    menagement = menagement.OrderBy(s => s.OrganizacjeT.Nazwa);
                    break;
                case "or_desc":
                    menagement = menagement.OrderByDescending(s => s.OrganizacjeT.Nazwa);
                    break;
                default:  // Name ascending 
                    menagement = menagement.OrderBy(s => s.Nazwisko);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(menagement.ToPagedList(pageNumber, pageSize));
        }
    }
}
