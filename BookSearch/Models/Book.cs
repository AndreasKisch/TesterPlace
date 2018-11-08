using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSearch.Models
{

    /// <summary>
    /// Class to hold values from
    /// xml doc and be displayed to
    /// users
    /// </summary>
    public class Book
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string PDate { get { return PublishDate.ToShortDateString(); } }

        public string Description { get; set; }

    }
}
