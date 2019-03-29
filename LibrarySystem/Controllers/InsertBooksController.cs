using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class InsertBooksController : Controller
    {
        //
        // GET: /InsertBooks/
        public ActionResult Index()
        {
            LibraryBook lib = new LibraryBook();
            return View(lib);
        }
        [HttpPost]
        public ActionResult Index(LibraryBook details)
        {
           using(librarySystem db = new librarySystem())
           {
               if (ModelState.IsValid)
               {
                   db.LibraryBooks.Add(details);
                   db.SaveChanges();
               }
               ModelState.Clear();
               ViewBag.SuccessMessage = "Book details are added successfully";
               return View("Index", new LibraryBook());
           }
           


            return View();
        }
	}
}