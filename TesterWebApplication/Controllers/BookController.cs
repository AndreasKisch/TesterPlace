using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TesterWebApplication.Controllers
{
    public class BookController : Controller
    {
        Dictionary<string,Book> bookList = new Dictionary<string, Book>();

        /// <summary>
        /// Access BooksearchAPI to get list of books
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(string sortOrder)
        {
            using (HttpResponseMessage res = await Helper.BookAPI.GetAsync("books/Get"))
            {

                if (res.IsSuccessStatusCode)
                {
                    bookList = await res.Content.ReadAsAsync< Dictionary<string, Book>> ();

                }

            }
            return View(bookList.Values.ToList());
        }


        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            //Book b = bookList

            return View();
        }

        public  ActionResult Edit(int? id)
        {

            return View();
        }




    }
}