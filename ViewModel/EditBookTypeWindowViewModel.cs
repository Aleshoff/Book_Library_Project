using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class EditBookTypeWindowViewModel:ViewModelBase
    {
        private int bookTypeId;
        public EditBookTypeWindowViewModel(int Id)
        {
            this.bookTypeId = Id;
            selectedBookType = DBUtils.getSelectedBookType(bookTypeId);
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
            //DBUtils.editSelectedBookType(selectedBookType[0]);
        }

        public void EditBookType()
        {
            DBUtils.editSelectedBookType(selectedBookType[0]);
        }
    }
}
