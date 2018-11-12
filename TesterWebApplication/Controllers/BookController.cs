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
        public async Task<IActionResult> Index(string searchValue)
        {

            Dictionary<string, Book> bookList = new Dictionary<string, Book>();

            using (HttpResponseMessage res = await APIHelper.BookAPI.GetAsync("books/GetSearch?searchValue=" + searchValue))
            {

                if (res.IsSuccessStatusCode)
                {
                    bookList = await res.Content.ReadAsAsync<Dictionary<string, Book>>();
                }

            }
            Helper.SessionHelper.Set<Dictionary<string, Book>>(HttpContext.Session, "bList", bookList);


            return View(Helper.SessionHelper.Get<Dictionary<string, Book>>(HttpContext.Session, "bList").Values.ToList());
        }


        /// <summary>
        /// Gets book that is suppose to be edited
        /// and sends it to for data to view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(string id)
        {
            Dictionary<string, Book> bList = Helper.SessionHelper.Get<Dictionary<string, Book>>(HttpContext.Session, "bList");
            Book b = bList[id];

            return View(b);
        }

        /// <summary>
        /// Sends a put request to update a book in the API
        /// then redirects back to Index view to see updates
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public async Task<IActionResult> Put(Book b)
        {

            await APIHelper.BookAPI.PutAsJsonAsync("books/put", b);

            return Redirect("Index");
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

        /// <summary>
        /// Opens a create view to add a 
        /// new book to the API
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Posts the book to the API
        /// </summary>
        /// <param name="b">book to be added</param>
        /// <returns></returns>
        public async Task<IActionResult> Post(Book b)
        {

            await APIHelper.BookAPI.PostAsJsonAsync("books/post", b);
            return Redirect("Index");
        }




    }
}