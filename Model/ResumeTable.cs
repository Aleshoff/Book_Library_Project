using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class ResumeTable
    {
        public int bookId { get; set; }
        public string Book_Title { get; set; }
        public string Book_Type_Name { get; set; }
        public string Publisher_Name { get; set; }
        public int Publish_Year { get; set; }
        public int Stock { get; set; }
        public string Author_First_Name { get; set; }
        public string Author_Last_Name { get; set; }

        public ResumeTable(int bookId, string book_Title, string book_Type_Name, string publisher_Name, int publish_Year, int stock, string author_First_Name, string author_Last_Name)
        {
            this.bookId = bookId;
            Book_Title = book_Title;
            Book_Type_Name = book_Type_Name;
            Publisher_Name = publisher_Name;
            Publish_Year = publish_Year;
            Stock = stock;
            Author_First_Name = author_First_Name;
            Author_Last_Name = author_Last_Name;
        }
    }
}
