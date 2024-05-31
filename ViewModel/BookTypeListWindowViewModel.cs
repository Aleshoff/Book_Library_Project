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
    class BookTypeListWindowViewModel:ViewModelBase
    {
        public BookTypeListWindowViewModel()
        {
            ObservableCollection<BookType> bookType = DBUtils.getBookTypeList();
            bookTypeView = CollectionViewSource.GetDefaultView(bookType);
        }

        private ICollectionView bookTypeView;

        public ICollectionView View
        {
            get { return bookTypeView; }
            set
            {
                bookTypeView = value;
                OnPropertyChanged();
            }
        }
        private bool BookTypeFilter(object item)
        {
            BookType bt = item as BookType;
            if (!string.IsNullOrEmpty(filteringString))
                return bt.name.ToLower().Contains(FilterString.ToLower());
            return true;
        }

        private string filteringString = string.Empty;
        public string FilterString
        {
            get { return filteringString; }
            set
            {
                filteringString = value;
                bookTypeView.Filter += BookTypeFilter;
                OnPropertyChanged();
            }
        }
    }
}
