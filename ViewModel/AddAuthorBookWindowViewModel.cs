using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddAuthorBookWindowViewModel:ViewModelBase
    {
        public AddAuthorBookWindowViewModel()
        {
            List<AuthorBook> authorBookList = new List<AuthorBook>();
            AuthorBook newAuthorBook = new AuthorBook(0, 0, 0, 0);
            authorBookList.Add(newAuthorBook);
            selectedAuthorBook = authorBookList;

            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<AuthorBook> selectedAuthorBook;
        public List<AuthorBook> SelectedElement
        {
            get { return selectedAuthorBook; }
            set
            {
                selectedAuthorBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedAuthorBook[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //DBUtils.addAuthorBook(selectedAuthorBook[0]);
        }

        public void AddAuthorBook()
        {
            DBUtils.addAuthorBook(selectedAuthorBook[0]);
        }
    }
}
