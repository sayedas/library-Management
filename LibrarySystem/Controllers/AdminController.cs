using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            librarySystem entity = new librarySystem();
            var BookRequest = entity.RecordsTables.Where(t => t.isApproved == false);
            return View(BookRequest);
        }
	}
}