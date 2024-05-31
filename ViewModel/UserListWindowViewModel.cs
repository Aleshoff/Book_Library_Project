using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BooksLibraryDB.ViewModel
{
    class UserListWindowViewModel:ViewModelBase
    {
        public UserListWindowViewModel()
        {
            ObservableCollection<User> users = DBUtils.getUserList();
            userView = CollectionViewSource.GetDefaultView(users);
        }

        private ICollectionView userView;

        public ICollectionView View
        {
            get { return userView; }
            set
            {
                userView = value;
                OnPropertyChanged();
            }
        }
        private bool UserFilter(object item)
        {
            User user = item as User;
            if (!string.IsNullOrEmpty(filteringString))
                return user.lastName.ToLower().Contains(FilterString.ToLower());
            return true;
        }

        private string filteringString = string.Empty;
        public string FilterString
        {
            get { return filteringString; }
            set
            {
                filteringString = value;
                userView.Filter += UserFilter;
                OnPropertyChanged();
            }
        }
    }
}
