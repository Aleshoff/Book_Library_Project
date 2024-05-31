using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BooksLibraryDB.Model;


namespace BooksLibraryDB.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

        }

        private string title = "The Book's Library";
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

    }
}

