using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using System.Data.Entity.Validation;

namespace LibrarySystem.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        public ActionResult Index()
        {
            if (Session["customerId"] != null)
            {
                Response.Redirect("~/Home/Index");
            }
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]   //when the form is filled and button is hit, the data is posted in this post action method.
        public ActionResult Index(Customer customer)   //The data is binded to the 'customer'
        {
            using (librarySystem db = new librarySystem())
            {
                if (db.Customers.Any(x => x.customerName == customer.customerName))    //if-else to avoid duplicate registering from the already rgistered name.
                {
                    ViewBag.DuplicateMessage = "This User Name Already Exists. Please try again.";
                    return View("Index", customer);
                }
                else
                {
                    db.Customers.Add(customer);            //Adding all the information to the database
                    db.SaveChanges();
                }  
            }
            ModelState.Clear();             //Rebuild the model to be passed to your view.
            ViewBag.SuccessMessage = "Done! Your Successfully Registered."; 

            return View("Index",new Customer());
        }
	}
}