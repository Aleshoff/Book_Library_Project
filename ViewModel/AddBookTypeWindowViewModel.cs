using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddBookTypeWindowViewModel:ViewModelBase
    {
        public AddBookTypeWindowViewModel()
        {
            List<BookType> bookTypeList = new List<BookType>();
            BookType newBookType = new BookType(0, "", true);
            bookTypeList.Add(newBookType);
            selectedBookType = bookTypeList;

            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<BookType> selectedBookType;
        public List<BookType> SelectedElement
        {
            get { return selectedBookType; }
            set
            {
                selectedBookType = value;
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedBookType[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //DBUtils.addBookType(selectedBookType[0]);
        }

        public void AddBookType()
        {
            DBUtils.addBookType(selectedBookType[0]);
        }
    }
}
