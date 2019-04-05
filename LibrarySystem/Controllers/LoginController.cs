using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            if (Session["customerId"] != null)
            {
                Response.Redirect("~/Home/Index");
            }
            return View();
        }
        [HttpPost]
        [OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Authorize(LibrarySystem.Models.Customer customerModel)
        {
            using (librarySystem db = new librarySystem())
            {
                //var customerDetail = db.Customers.Where(x => x.customerName == customerModel.customerName && x.password == customerModel.password).FirstOrDefault();
                //if (customerDetail == null)
                //{
                //    ViewBag.DuplicateMessage = "Wrong Username and Password";
                //    return View("Index", customerModel);
                //}
                //else
                //{
                //    Session["customerName"] = customerDetail.customerName;   
                //    Session["customerId"] = customerDetail.customerId;
                //    return RedirectToAction("Index", "Home");
                //}


                var customerDetail = db.Customers.Where(x => x.customerName == customerModel.customerName && x.password == customerModel.password).FirstOrDefault();
                if (customerModel.customerName == "admin" && customerModel.password == "admin")
                {
                    return RedirectToAction("Index", "Admin");    //opens admin Dashboard.
                }
                else if (customerDetail == null)
                {
                    ViewBag.DuplicateMessage = "Wrong Username and Password";
                    return View("Index", customerModel);
                }
               
                else
                {
                    Session["customerName"] = customerDetail.customerName;
                    Session["customerId"] = customerDetail.customerId;
                    return RedirectToAction("Index", "Home");
                }
            }
             return View();
        }
	}
}