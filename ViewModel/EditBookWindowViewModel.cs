using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class EditBookWindowViewModel : ViewModelBase
    {
        private int bookId;
        public EditBookWindowViewModel(int Id)
        {
            this.bookId = Id;
            selectedBook = DBUtils.getSelectedBook(bookId);
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
            //DBUtils.editSelectedBook(selectedBook[0]);
        }

        public void EditBook()
        {
            DBUtils.editSelectedBook(selectedBook[0]);
        }
    }
}
