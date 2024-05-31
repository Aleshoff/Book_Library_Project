using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class Author
    {
        public int authorId { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public bool isActive { get; set; }

        public Author(int authorId, string firstname, string lastName, string birthDate, bool isActive)
        {
            this.authorId = authorId;
            this.firstname = firstname;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.isActive = isActive;
        }

        public bool isValid()
        {
            if (firstname == string.Empty || lastName == string.Empty || birthDate == string.Empty)
                return false;
            return true;
        }
    }
}
