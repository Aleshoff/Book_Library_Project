using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool isActive { get; set; }

        public User(int userId, string firstName, string lastName, string email, string phone, bool isActive)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.isActive = isActive;
        }

        public bool isValid()
        {
            if (firstName == string.Empty || lastName == string.Empty || email == string.Empty || phone == string.Empty)
                return false;
            return true;
        }
    }
}
