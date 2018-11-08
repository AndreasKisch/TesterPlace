using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSearch.Controllers
{
    /// <summary>
    /// Controller handeling access to 
    /// xml-file allowing adding, removing and getting
    /// book items
    /// </summary>
    [Route("books/")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookServices _services;

        public BookController(IBookServices services)
        {
            _services = services;
        }


        /// <summary>
        /// Gets the elements contained within 
        /// Xml document
        /// </summary>
        /// <returns>List of books</returns>
        [Route("Get")]
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {

            var bookList = _services.GetBookList();

            if (bookList == null)
            {
                return NotFound();
            }

            return bookList.Values.ToList();
        }

        /// <summary>
        /// Allows user to add elements to
        /// bookList and Xml-doc
        /// </summary>
        /// <param name="b">Object to be added</param>
        /// <returns></returns>
        [Route("Post")]
        [HttpPost]
        public ActionResult<List<Book>> Post(Book b)
        {

            var bookList = _services.AddBook(b);

            if (bookList == null)
            {
                return NotFound();
            }

            return Ok(bookList);
        }
    }




}