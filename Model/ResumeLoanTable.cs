using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class ResumeLoanTable
    {
        public int userBookId { get; set; }
        public string first_Name { get; set; }
        public string last_Name { get; set; }
        public string book_Title { get; set; }
        public string start_Date { get; set; }
        public string return_Date { get; set; }

        public ResumeLoanTable(int userBookId, string first_Name, string last_Name, string book_Title, string start_Date, string return_Date)
        {
            this.userBookId = userBookId;
            this.first_Name = first_Name;
            this.last_Name = last_Name;
            this.book_Title = book_Title;
            this.start_Date = start_Date;
            this.return_Date = return_Date;
        }
    }
}
