using BooksLibraryDB.Model;
using BooksLibraryDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksLibraryDB.View
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage(ViewModelBase vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void DataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString().Contains("Id") || e.Column.Header.ToString().Contains("Active"))
            {
                e.Cancel = true;
            }
        }

        #region Data Grid Double Click

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid1.SelectedItem == null)
                return;
            object objBook = new BookListWindowViewModel();
            object objPublisher = new PublisherListWindowViewModel();
            object objAuthor = new AuthorListWindowViewModel();
            object objBookType = new BookTypeListWindowViewModel();
            object objUser = new UserListWindowViewModel();
            object objLoan = new UserBookListWindowViewModel();
            if (this.DataContext.GetType() == objBook.GetType())
            {
                editBookWindow();
                return;
            }
            if (this.DataContext.GetType() == objPublisher.GetType())
            {
                editPublisherWindow();
                return;
            }
            if (this.DataContext.GetType() == objAuthor.GetType())
            {
                editAuthorWindow();
                return;
            }
            if (this.DataContext.GetType() == objBookType.GetType())
            {
                editBookTypeWindow();
                return;
            }
            if (this.DataContext.GetType() == objUser.GetType())
            {
                editUserWindow();
                return;
            }
            if (this.DataContext.GetType() == objLoan.GetType())
            {
                editUserBookWindow();
                return;
            }
        }
        #endregion

        #region Edit Windows View

        private void editBookWindow()
        {
            ResumeTable rt = DataGrid1.SelectedItem as ResumeTable;
            int bookId = rt.bookId;

            Page page = new AddEditPage();
            page.DataContext = new EditBookWindowViewModel(bookId);
            NavigationService.Navigate(page);
        }

        private void editPublisherWindow()
        {
            Publisher p = DataGrid1.SelectedItem as Publisher;
            int publisherId = p.publisherId;

            Page page = new AddEditPage();
            page.DataContext = new EditPublisherWindowViewModel(publisherId);
            NavigationService.Navigate(page);
        }

        private void editAuthorWindow()
        {
            Author aut = DataGrid1.SelectedItem as Author;
            int authorId = aut.authorId;

            Page page = new AddEditPage();
            page.DataContext = new EditAuthorWindowViewModel(authorId);
            NavigationService.Navigate(page);
        }

        private void editBookTypeWindow()
        {
            BookType bt = DataGrid1.SelectedItem as BookType;
            int bookTypeId = bt.bookTypeId;

            Page page = new AddEditPage();
            page.DataContext = new EditBookTypeWindowViewModel(bookTypeId);
            NavigationService.Navigate(page);
        }

        private void editUserWindow()
        {
            User user = DataGrid1.SelectedItem as User;
            int userId = user.userId;

            Page page = new AddEditPage();
            page.DataContext = new EditUserWindowViewModel(userId);
            NavigationService.Navigate(page);
        }

        private void editUserBookWindow()
        {
            ResumeLoanTable rlt = DataGrid1.SelectedItem as ResumeLoanTable;
            int loanId = rlt.userBookId;

            Page page = new AddEditPage();
            page.DataContext = new EditUserBookWindowViewModel(loanId);
            NavigationService.Navigate(page);
        }


        #endregion

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.ScrollIntoView(DataGrid1.Items.GetItemAt(DataGrid1.Items.Count - 1));
        }
    }
}
