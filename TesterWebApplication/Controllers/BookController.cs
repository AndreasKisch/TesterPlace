using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace TesterWebApplication.Controllers
{
    public class BookController : Controller
    {

        /// <summary>
        /// Access BooksearchAPI to get list of books
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(string sortOrder)
        {

            Dictionary<string, Book> bookList = new Dictionary<string, Book>();

            using (HttpResponseMessage res = await APIHelper.BookAPI.GetAsync("books/Get"))
            {

                if (res.IsSuccessStatusCode)
                {
                    bookList = await res.Content.ReadAsAsync<Dictionary<string, Book>>();
                }

            }
            if (Helper.SessionHelper.Get<Dictionary<string, Book>>(HttpContext.Session, "bList") == null)
            {
                Helper.SessionHelper.Set<Dictionary<string, Book>>(HttpContext.Session, "bList", bookList);
            }

            return View(Helper.SessionHelper.Get<Dictionary<string, Book>>(HttpContext.Session, "bList").Values.ToList());
        }

        /// <summary>
        /// Give detailed view of the book
        /// with description
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            Dictionary<string, Book> books =
                Helper.SessionHelper.Get<Dictionary<string, Book>>(HttpContext.Session, "bList");

            return View(books[id]);
        }




    }
}