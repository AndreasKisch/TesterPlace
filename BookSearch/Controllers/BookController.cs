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
    /// dictionary containing info regarding 
    /// books
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
        public ActionResult<Dictionary<string, Book>> Get()
        {

            var bookList = _services.GetBookList();

            if (bookList == null)
            {
                return NotFound();
            }
            return bookList;
        }

        [Route("GetSearch")]
        [HttpGet]
        public ActionResult<Dictionary<string, Book>> Get(string searchValue)
        {

            var bookList = _services.GetBookList(searchValue);

            if (bookList == null)
            {
                return NotFound();
            }
            return bookList;
        }

        /// <summary>
        /// Allows user to add elements to
        /// bookList
        /// </summary>
        /// <param name="b">Object to be added</param>
        /// <returns></returns>
        [Route("Post")]
        [HttpPost]
        public ActionResult<List<Book>> Post(Book b)
        {

            var book = _services.AddBook(b);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Updates information of a book stored in services bookList
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        [Route("Put")]
        [HttpPut]
        public ActionResult Put(Book b)
        {
            var book = _services.UpdateBook(b);

            if (book == null)
            {
                BadRequest(b);
            }

            return Ok(b);
        }

    }




}