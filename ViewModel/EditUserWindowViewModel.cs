using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class EditUserWindowViewModel:ViewModelBase
    {
        private int userId;
        public EditUserWindowViewModel(int Id)
        {
            this.userId = Id;
            selectedUser = DBUtils.getSelectedUser(userId);
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
            //DBUtils.editSelectedUser(selectedUser[0]);
        }

        public void EditUser()
        {
            DBUtils.editSelectedUser(selectedUser[0]);
        }
    }
}
