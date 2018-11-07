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

        string sortOrder;
        /// <summary>
        /// Access BooksearchAPI to get list of books
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(string _sortOrder)
        {
            using (HttpResponseMessage res = await Helper.BookAPI.GetAsync("books/Get"))
            {
                sortOrder = _sortOrder;
                if (res.IsSuccessStatusCode)
                {
                    BookList = await res.Content.ReadAsAsync<List<Book>>();

                }

            }
            ViewBag.BookList = BookList;

            switch (sortOrder)
            {
                case "Author":
                    BookList = BookList.OrderBy(b => b.Author).ToList();
                    break;
                case "Title":
                    BookList = BookList.OrderBy(b => b.Title).ToList();
                    break;
                case "Price":
                    BookList = BookList.OrderBy(b => b.Price).ToList();
                    break;
                case "Genre":
                    BookList = BookList.OrderBy(b => b.Genre).ToList();
                    break;
                case "PDate":
                    BookList = BookList.OrderBy(b => b.PublishDate).ToList();
                    break;
                default:
                    BookList = BookList.OrderBy(b => b.Author).ToList();
                    break;
            }
            


            return View(BookList);
        }
        
    }
}