using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class EditAuthorWindowViewModel:ViewModelBase
    {
        private int authorId;
        public EditAuthorWindowViewModel(int Id)
        {
            this.authorId = Id;
            selectedAuthor = DBUtils.getSelectedAuthor(authorId);
            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<Author> selectedAuthor;
        public List<Author> SelectedElement
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                OnPropertyChanged();
            }
        }
        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedAuthor[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //DBUtils.editSelectedAuthor(selectedAuthor[0]);
        }

        public void EditAuthor()
        {
            DBUtils.editSelectedAuthor(selectedAuthor[0]);
        }
    }
}
