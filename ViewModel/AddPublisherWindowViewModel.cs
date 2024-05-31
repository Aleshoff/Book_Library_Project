using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksLibraryDB.ViewModel
{
    class AddPublisherWindowViewModel:ViewModelBase
    {
        public AddPublisherWindowViewModel()
        {
            List<Publisher> publisherList = new List<Publisher>();
            Publisher newPublisher = new Publisher(0, "", "", true);
            publisherList.Add(newPublisher);
            selectedPublisher = publisherList;

            addCommand = new RelayCommand(onAddCommandExecuted, canAddCommandExecute);
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
            //DBUtils.addPublisher(selectedPublisher[0]);
        }

        public void AddPublisher()
        {
            DBUtils.addPublisher(selectedPublisher[0]);
        }
    }
}
