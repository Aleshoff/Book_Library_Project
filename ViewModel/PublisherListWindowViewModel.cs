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
    class PublisherListWindowViewModel : ViewModelBase
    {
        public PublisherListWindowViewModel()
        {
            ObservableCollection<Publisher> publishers = DBUtils.getPublisherList();
            publisherView = CollectionViewSource.GetDefaultView(publishers);
        }

        private ICollectionView publisherView;

        public ICollectionView View
        {
            get { return publisherView; }
            set
            {
                publisherView = value;
                OnPropertyChanged();
            }
        }
        private bool PublisherFilter(object item)
        {
            Publisher rt = item as Publisher;
            if (!string.IsNullOrEmpty(filteringString))
                return rt.name.ToLower().Contains(FilterString.ToLower());
            return true;
        }

        private string filteringString = string.Empty;
        public string FilterString
        {
            get { return filteringString; }
            set
            {
                filteringString = value;
                publisherView.Filter += PublisherFilter;
                OnPropertyChanged();
            }
        }
    }
}
