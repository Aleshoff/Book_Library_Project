using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class Book
    {
        public int bookId { get; set; }
        public int bookTypeId { get; set; }
        public int publisherId { get; set; }
        public string title { get; set; }
        public int publishYear { get; set; }
        public int stock { get; set; }
        public bool isActive { get; set; }


        public Book(int bookId, int bookTypeId, int publisherId, string title, int publishYear, int stock, bool isActive)
        {
            this.bookId = bookId;
            this.bookTypeId = bookTypeId;
            this.publisherId = publisherId;
            this.title = title;
            this.publishYear = publishYear;
            this.stock = stock;
            this.isActive = isActive;
        }

        public bool isValid()
        {
            if (bookTypeId <= 0 || publisherId <= 0 || title == string.Empty || publishYear <= 0 || stock < 0)
                return false;
            return true;
        }
    }
}
