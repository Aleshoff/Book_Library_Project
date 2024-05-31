using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class UserBook
    {
        public int loanId { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public string startDate { get; set; }
        public string returnDate { get; set; }
        public UserBook(int loanId, int userId, int bookId, string startDate, string returnDate)
        {
            this.loanId = loanId;
            this.userId = userId;
            this.bookId = bookId;
            this.startDate = startDate;
            this.returnDate = returnDate;
        }

    public void setLoan(UserBook ub)
        {
            UserBook tempUserBook = ub;
            if (tempUserBook.returnDate == string.Empty)
                tempUserBook.returnDate = null;

            DBUtils.addUserBook(tempUserBook);
        }

        public void editLoan(UserBook ub)
        {
            UserBook tempUserBook = ub;
            if (tempUserBook.returnDate == string.Empty)
                tempUserBook.returnDate = null;

            DBUtils.editSelectedUserBook(tempUserBook);

        }
        public bool isValid()
        {
            if (userId <= 0 || bookId <= 0 || startDate == string.Empty)
                return false;
            return true;
        }

        public bool isStock()
        {
            int tempStock = 0;
            int tempLoans = 0;

            List<Book> bookList = DBUtils.getSelectedBook(this.bookId);
            if(bookList.Count != 0)
            {
                tempStock = bookList[0].stock;
                tempLoans = DBUtils.getLoansNumber(this.bookId);
            }

            if (tempStock - tempLoans == 0)
                return false;
            return true;
        }
    }
}
