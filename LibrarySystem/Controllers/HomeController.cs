using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        librarySystem entities = new librarySystem();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            
             int customerid = Convert.ToInt32(Session["customerId"]);
                librarySystem entities = new librarySystem();

                var BookRecord = entities.RecordsTables.Where(t => t.customerId == customerid);   //The customer id from the database should match session customer Id.

                 //(from records in entities.RecordsTables select records).ToList();
             return View(BookRecord);
        }        
	}
}