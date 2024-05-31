using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class EditPublisherWindowViewModel:ViewModelBase
    {
        private int publisherId;
        public EditPublisherWindowViewModel(int Id)
        {
            this.publisherId = Id;
            selectedPublisher = DBUtils.getSelectedPublisher(publisherId);
            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
        }

        private string title = "Edit Publisher";
        public string Title
        {
            get => title;
            set
            {
                if (Equals(title, value)) return;
                title = value;
                OnPropertyChanged();
            }
        }

        private List<Publisher> selectedPublisher;
        public List<Publisher> SelectedElement
        {
            get { return selectedPublisher; }
            set
            {
                selectedPublisher = value;
                OnPropertyChanged();
            }
        }
        public ICommand addCommand { get; }
        private bool canAddCommandExecute(object parameter)
        {
            if (!selectedPublisher[0].isValid())
                return false;
            return true;
        }

        private void onAddCommandExecuted(object parameter)
        {
            //DBUtils.editSelectedPublisher(selectedPublisher[0]);
        }

        public void EditPublisher()
        {
            DBUtils.editSelectedPublisher(selectedPublisher[0]);
        }
    }
}
