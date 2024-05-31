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
    class UserBookListWindowViewModel:ViewModelBase
    {
        public UserBookListWindowViewModel()
        {
            ObservableCollection<ResumeLoanTable> loans = DBUtils.getLoansList();
            loanView = CollectionViewSource.GetDefaultView(loans);

        }

        private ICollectionView loanView;

        public ICollectionView View
        {
            get { return loanView; }
            set
            {
                loanView = value;
                OnPropertyChanged();
            }
        }

        private bool LoanFilter(object item)
        {
            ResumeLoanTable rlt = item as ResumeLoanTable;
            if (!string.IsNullOrEmpty(filteringString))
                return rlt.last_Name.ToLower().Contains(FilterString.ToLower());
            return true;
        }

        private string filteringString = string.Empty;
        public string FilterString
        {
            get { return filteringString; }
            set
            {
                filteringString = value;
                loanView.Filter += LoanFilter;
                OnPropertyChanged();
            }
        }

        private ResumeLoanTable loan;

        public ResumeLoanTable Item
        {
            get { return loan; }
            set
            {
                loan = value;
                OnPropertyChanged();
            }
        }
    }
}
