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

        public async Task<IActionResult> Index()
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