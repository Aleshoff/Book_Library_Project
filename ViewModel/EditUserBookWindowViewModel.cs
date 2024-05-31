using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class EditUserBookWindowViewModel:ViewModelBase
    {
        private int loanId;
        public EditUserBookWindowViewModel(int Id)
        {
            this.loanId = Id;
            selectedLoan = DBUtils.getSelectedUserBook(loanId);
            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private List<UserBook> selectedLoan;
        public List<UserBook> SelectedElement
        {
            get { return selectedLoan; }
            set
            {
                selectedLoan = value;
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedLoan[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //UserBook ub = selectedLoan[0];
            //ub.editLoan(ub);
        }

        public void EditUserBook()
        {
            UserBook ub = selectedLoan[0];
            ub.editLoan(ub);
        }
    }
}
