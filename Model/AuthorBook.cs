using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class AuthorBook
    {
        public int id { get; set; }
        public int authorId { get; set; }
        public int bookId { get; set; }
        public int numberInList { get; set; }
        public AuthorBook(int id, int authorId, int bookId, int numberInList)
        {
            this.id = id;
            this.authorId = authorId;
            this.bookId = bookId;
            this.numberInList = numberInList;
        }

        public bool isValid()
        {
            if (authorId <= 0 || bookId <= 0 || numberInList <= 0)
                return false;
            return true;
        }
    }
}
