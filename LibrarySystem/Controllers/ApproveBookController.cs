using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class ApproveBookController : Controller
    {
        //
        // GET: /ApproveBook/
        public ActionResult Index(int bookid, int customerid)
        {
            librarySystem ent = new librarySystem();
           
            var approveRequest = ent.RecordsTables.Where(t => t.customerId == customerid && t.BookId==bookid);
            approveRequest.FirstOrDefault().isApproved = true;
            ent.SaveChanges();
            return RedirectToAction("Index", "Admin");
           
        }
	}
}