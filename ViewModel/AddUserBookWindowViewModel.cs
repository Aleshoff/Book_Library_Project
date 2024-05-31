using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddUserBookWindowViewModel:ViewModelBase
    {
        public AddUserBookWindowViewModel()
        {
            List<UserBook> userBookList = new List<UserBook>();
            UserBook newUserBook = new UserBook(0, 0, 0, "", "");
            userBookList.Add(newUserBook);
            selectedUserBook = userBookList;

            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<UserBook> selectedUserBook;
        public List<UserBook> SelectedElement
        {
            get { return selectedUserBook; }
            set
            {
                selectedUserBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedUserBook[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //UserBook ub = selectedUserBook[0];
            //if (!ub.isStock())
                //return;
            //ub.setLoan(ub);
        }

        public void AddUserBook()
        {
            UserBook ub = selectedUserBook[0];
            if (!ub.isStock())
                return;
            ub.setLoan(ub);
        }
    }
}
