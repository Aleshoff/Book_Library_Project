using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryDB.Model
{
    public class Publisher
    {
        public int publisherId { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public bool isActive { get; set; }

        public Publisher(int publisherId, string name, string adress, bool isActive)
        {
            this.publisherId = publisherId;
            this.name = name;
            this.adress = adress;
            this.isActive = isActive;
        }

        public bool isValid()
        {
            if (name == string.Empty || adress == string.Empty)
                return false;
            return true;
        }
    }


}
