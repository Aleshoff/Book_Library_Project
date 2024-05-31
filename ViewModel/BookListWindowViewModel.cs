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
    class BookListWindowViewModel : ViewModelBase
    {
        public BookListWindowViewModel()
        {
            ObservableCollection<ResumeTable> books = DBUtils.getBookList();
            bookView = CollectionViewSource.GetDefaultView(books);
             
        }

        private ICollectionView bookView;

        public ICollectionView View
        {
            get { return bookView; }
            set
            {
                bookView = value;
                OnPropertyChanged();
            }
        }

        private bool BookFilter(object item)
        {
            ResumeTable rt = item as ResumeTable;
            if(!string.IsNullOrEmpty(filteringString))
                return rt.Book_Title.ToLower().Contains(FilterString.ToLower());
            return true;
        }

        private string filteringString = string.Empty;
        public string FilterString
        {
            get { return filteringString; }
            set
            {
                try
                {
                    filteringString = value;
                    bookView.Filter += BookFilter;
                    OnPropertyChanged();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception");
                }
            }
        }

        private ResumeTable book;

        public ResumeTable Item
        {
            get { return book; }
            set
            {
                book = value;
                OnPropertyChanged();
            }
        }

        public int getBookId()
        {
            return Item.bookId;
        } 
    }
}
