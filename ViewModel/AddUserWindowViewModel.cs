using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddUserWindowViewModel:ViewModelBase
    {
        public AddUserWindowViewModel()
        {
            List<User> userList = new List<User>();
            User newUser = new User(0, "", "", "", "", true);
            userList.Add(newUser);
            selectedUser = userList;

            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<User> selectedUser;
        public List<User> SelectedElement
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedUser[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //DBUtils.addUser(selectedUser[0]);
        }

        public void AddUser()
        {
            DBUtils.addUser(selectedUser[0]);
        }
    }
}
