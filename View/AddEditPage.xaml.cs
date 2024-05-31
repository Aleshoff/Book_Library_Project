using BooksLibraryDB.Model;
using BooksLibraryDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public AddEditPage()
        {
            InitializeComponent();
        }

        private void DataGrid2_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            object objAddBook = new AddBookWindowViewModel();
            object objAddAuthorBook = new AddAuthorBookWindowViewModel();
            object objEditBook = new EditBookWindowViewModel(1);
            object objAddLoan = new AddUserBookWindowViewModel();
            if ((this.DataContext.GetType() != objAddBook.GetType() && this.DataContext.GetType() != objAddAuthorBook.GetType() &&
                e.Column.Header.ToString().Contains("Id") && this.DataContext.GetType() != objEditBook.GetType() && this.DataContext.GetType() != objAddLoan.GetType()) ||
               (this.DataContext.GetType() == objAddBook.GetType() && e.Column.Header.ToString().Contains("bookId")) ||
               (this.DataContext.GetType() == objAddAuthorBook.GetType() && e.Column.Header.ToString().Contains("id")) ||
               (this.DataContext.GetType() == objEditBook.GetType() && e.Column.Header.ToString().Contains("bookId")) ||
               (this.DataContext.GetType() == objAddLoan.GetType() && e.Column.Header.ToString().Contains("loanId")))
            {
                e.Cancel = true;
            }
        }
        private  void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext.GetType() == new AddUserBookWindowViewModel().GetType())
            {
                object objAddLoan = new AddUserBookWindowViewModel();
                UserBook ub = (UserBook)this.DataGrid2.SelectedItem;
                if (!ub.isStock() && this.DataContext.GetType() == objAddLoan.GetType())
                {
                    MessageBox.Show("Stock is 0! Try another one!");
                    return;
                }
                AddUserBookWindowViewModel model = (AddUserBookWindowViewModel)this.DataContext;
                model.AddUserBook();
                NavigationService.Navigate(new ListPage(new UserBookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditAuthorWindowViewModel(1).GetType())
            {
                EditAuthorWindowViewModel model = (EditAuthorWindowViewModel)this.DataContext; 
                model.EditAuthor(); 
                NavigationService.Navigate(new ListPage(new AuthorListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditPublisherWindowViewModel(1).GetType())
            {
                EditPublisherWindowViewModel model = (EditPublisherWindowViewModel)this.DataContext;
                model.EditPublisher();
                NavigationService.Navigate(new ListPage(new PublisherListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditBookTypeWindowViewModel(1).GetType())
            {
                EditBookTypeWindowViewModel model = (EditBookTypeWindowViewModel)this.DataContext;
                model.EditBookType();
                NavigationService.Navigate(new ListPage(new BookTypeListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditBookWindowViewModel(1).GetType())
            {
                EditBookWindowViewModel model = (EditBookWindowViewModel)this.DataContext;
                model.EditBook();
                NavigationService.Navigate(new ListPage(new BookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditUserBookWindowViewModel(1).GetType())
            {
                EditUserBookWindowViewModel model = (EditUserBookWindowViewModel)this.DataContext;
                model.EditUserBook();
                NavigationService.Navigate(new ListPage(new UserBookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditUserWindowViewModel(1).GetType())
            {
                EditUserWindowViewModel model = (EditUserWindowViewModel)this.DataContext;
                model.EditUser();
                NavigationService.Navigate(new ListPage(new UserListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddAuthorWindowViewModel().GetType())
            {
                AddAuthorWindowViewModel model = (AddAuthorWindowViewModel)this.DataContext;
                model.AddAuthor();
                NavigationService.Navigate(new ListPage(new AuthorListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddPublisherWindowViewModel().GetType())
            {
                AddPublisherWindowViewModel model = (AddPublisherWindowViewModel)this.DataContext;
                model.AddPublisher();
                NavigationService.Navigate(new ListPage(new PublisherListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddBookTypeWindowViewModel().GetType())
            {
                AddBookTypeWindowViewModel model = (AddBookTypeWindowViewModel)this.DataContext;
                model.AddBookType();
                NavigationService.Navigate(new ListPage(new BookTypeListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddUserWindowViewModel().GetType())
            {
                AddUserWindowViewModel model = (AddUserWindowViewModel)this.DataContext;
                model.AddUser();
                NavigationService.Navigate(new ListPage(new UserListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddBookWindowViewModel().GetType())
            {
                AddBookWindowViewModel model = (AddBookWindowViewModel)this.DataContext;
                model.AddBook();
                AddEditPage page = new AddEditPage();
                page.DataContext = new AddAuthorBookWindowViewModel();
                NavigationService.Navigate(page);
            }
            if (this.DataContext.GetType() == new AddAuthorBookWindowViewModel().GetType())
            {
                AddAuthorBookWindowViewModel model = (AddAuthorBookWindowViewModel)this.DataContext;
                model.AddAuthorBook();
                NavigationService.Navigate(new ListPage(new BookListWindowViewModel()));
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext.GetType() == new AddUserBookWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new UserBookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditAuthorWindowViewModel(1).GetType())
            {
                NavigationService.Navigate(new ListPage(new AuthorListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditPublisherWindowViewModel(1).GetType())
            {
                NavigationService.Navigate(new ListPage(new PublisherListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditBookTypeWindowViewModel(1).GetType())
            {
                NavigationService.Navigate(new ListPage(new BookTypeListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditBookWindowViewModel(1).GetType())
            {
                NavigationService.Navigate(new ListPage(new BookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditUserBookWindowViewModel(1).GetType())
            {
                NavigationService.Navigate(new ListPage(new UserBookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new EditUserWindowViewModel(1).GetType())
            {
                NavigationService.Navigate(new ListPage(new UserListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddAuthorWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new AuthorListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddPublisherWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new PublisherListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddBookTypeWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new BookTypeListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddUserWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new UserListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddBookWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new BookListWindowViewModel()));
            }
            if (this.DataContext.GetType() == new AddAuthorBookWindowViewModel().GetType())
            {
                NavigationService.Navigate(new ListPage(new BookListWindowViewModel()));
            }
        }
    }
}
