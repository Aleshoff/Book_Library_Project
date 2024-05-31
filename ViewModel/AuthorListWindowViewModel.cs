using BooksLibraryDB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BooksLibraryDB.ViewModel
{
    class AuthorListWindowViewModel: ViewModelBase
    {
        public AuthorListWindowViewModel()
        {
            ObservableCollection<Author> authors = DBUtils.getAuthorList();
            authorView = CollectionViewSource.GetDefaultView(authors);
        }

        private ICollectionView authorView;

        public ICollectionView View
        {
            get { return authorView; }
            set
            {
                authorView = value;
                OnPropertyChanged();
            }
        }
        private bool AuthorFilter(object item)
        {
            Author aut = item as Author;
            if (!string.IsNullOrEmpty(filteringString))
                return aut.lastName.ToLower().Contains(FilterString.ToLower());
            return true;
        }

        private string filteringString = string.Empty;
        public string FilterString
        {
            get { return filteringString; }
            set
            {
                filteringString = value;
                authorView.Filter += AuthorFilter;
                OnPropertyChanged();
            }
        }
    }
}
