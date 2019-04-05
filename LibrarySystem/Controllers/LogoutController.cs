using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class LogoutController : Controller
    {
        //
        // GET: /Logout/
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            // Redirecting to Login page after deleting Session
            return RedirectToAction("Index", "Login");
           
        }
	}
}