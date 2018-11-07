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
        List<Book> BookList = new List<Book>();

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
                    BookList = await res.Content.ReadAsAsync<List<Book>>();

                }

            }
            return View(BookList);
        }

    }
}