using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddAuthorWindowViewModel:ViewModelBase
    {
        public AddAuthorWindowViewModel()
        {
            List<Author> authorList = new List<Author>();
            Author newAuthor = new Author(0, "", "", "", true);
            authorList.Add(newAuthor);
            selectedAuthor = authorList;

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
            //DBUtils.addAuthor(selectedAuthor[0]);
        }

        public void AddAuthor()
        {
            DBUtils.addAuthor(selectedAuthor[0]);
        }
    }
}
