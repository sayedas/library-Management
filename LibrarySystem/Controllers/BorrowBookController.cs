using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class BorrowBookController : Controller
    {
        //
        // GET: /BorrowBook/
        public ActionResult Index()
        {
            List<SelectListItem> BookList = GetBooks();
            return View(BookList);
        }

        [HttpPost]
        public ActionResult Index(string ddlBooks)
        {
            List<SelectListItem> BookList = GetBooks();
            if (!string.IsNullOrEmpty(ddlBooks))
            {
                SelectListItem selectedItem = BookList.Find(p => p.Value == ddlBooks);
                //ViewBag.Message = "Name: " + selectedItem.Text;
                //ViewBag.Message += "\\nID: " + selectedItem.Value;
                int BookId=Convert.ToInt32(ddlBooks);
                 librarySystem entities = new librarySystem();
                 var record = entities.RecordsTables.Where(x => x.BookId == BookId).Count();   //same book assigned to user (if less than 10 goes in if statement)
                 if (record < 10)
                 {
                      int customerid = Convert.ToInt32(Session["customerId"]);
                      var avalibility = entities.RecordsTables.Where(x => x.BookId == BookId && x.customerId == customerid).Count();//not assigning the same book again to the same user(if the book is not assigned goes to the if statement.)
                     if (avalibility == 0)
                     {
                         var recordData = new RecordsTable { BookId = BookId, customerId = customerid, isApproved=false, IssueDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(7) };
                         entities.RecordsTables.Add(recordData);
                         entities.SaveChanges();
                         return RedirectToAction("Index", "Home");
                     }
                     else
                     {
                         ViewBag.Message = "Book is borrowed already!";
                         return View(BookList);
                     }

                     
                 }
                 else
                 {
                     ViewBag.Message = "Book is not available";
                     return View(BookList);
                 }
            }
            return View(BookList);
        }

        private static List<SelectListItem> GetBooks()
        {
            librarySystem entities = new librarySystem();
            List<SelectListItem> BookList = (from p in entities.LibraryBooks.AsEnumerable()   //Here all the books from the database are taken and put them in the dropdown list.
                                                 select new SelectListItem
                                                 {
                                                     Text = p.Title,
                                                     Value = p.BookId.ToString()
                                                 }).ToList();


            //Add Default Item at First Position.
            BookList.Insert(0, new SelectListItem { Text = "--Select Here--", Value = "" });
            return BookList;
        }
	}
}