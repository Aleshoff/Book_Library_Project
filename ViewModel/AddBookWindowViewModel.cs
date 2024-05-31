using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddBookWindowViewModel:ViewModelBase
    {
        public AddBookWindowViewModel()
        {
            List<Book> bookList = new List<Book>();
            Book newBook = new Book(0, 0, 0, "", 0, 0, true);
            bookList.Add(newBook);
            selectedBook = bookList;

            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<Book> selectedBook;
        public List<Book> SelectedElement
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedBook[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //DBUtils.addBook(selectedBook[0]);
        }

        public void AddBook()
        {
            DBUtils.addBook(selectedBook[0]);
        }
    }
}
