using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookSearch.Models;


namespace BookSearch
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IBookServices
    {
        Book AddBook(Book b);
        Dictionary<string, Book> GetBookList();
        Dictionary<string, Book> GetBookList(string searchValue);
        object UpdateBook(Book b);
        int SetID();
    }
}
