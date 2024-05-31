using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class BookType
    {
        public int bookTypeId { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
        public BookType(int bookTypeId, string name, bool isActive)
        {
            this.bookTypeId = bookTypeId;
            this.name = name;
            this.isActive = isActive;
        }

        public bool isValid()
        {
            if (name == string.Empty)
                return false;
            return true;
        }
    }
}
