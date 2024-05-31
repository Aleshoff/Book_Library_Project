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
using BooksLibraryDB.ViewModel;
using BooksLibraryDB.Model;
using BooksLibraryDB.View;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace BooksLibraryDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            frmMain.Content = new StartPage();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void DataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString().Contains("Id") || e.Column.Header.ToString().Contains("Active"))
            {
                e.Cancel = true;
            }
        }

        #region Menu Click List Methods
        private void MenuAuthorList_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ListPage(new AuthorListWindowViewModel());
            page.DataContext = new AuthorListWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuPublisherList_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ListPage(new PublisherListWindowViewModel());
            page.DataContext = new PublisherListWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuBookList_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ListPage(new BookListWindowViewModel());
            page.DataContext = new BookListWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuBookType_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ListPage(new BookTypeListWindowViewModel());
            page.DataContext = new BookTypeListWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuUserList_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ListPage(new UserListWindowViewModel());
            page.DataContext = new UserListWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuBookLoanList_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ListPage(new UserBookListWindowViewModel());
            page.DataContext = new UserBookListWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        #endregion

        
        #region Menu Add Click Methods

        private void MenuAuthorAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new AddEditPage();
            page.DataContext = new AddAuthorWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuPublisherAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new AddEditPage();
            page.DataContext = new AddPublisherWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuBookTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new AddEditPage();
            page.DataContext = new AddBookTypeWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuBooksAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new AddEditPage();
            page.DataContext = new AddBookWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuUserAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new AddEditPage();
            page.DataContext = new AddUserWindowViewModel();
            frmMain.Content = page;
            this.DataContext = page.DataContext;
        }

        private void MenuBookLoansAdd_Click(object sender, RoutedEventArgs e)
        {
            Page page = new AddEditPage();
            page.DataContext = new AddUserBookWindowViewModel();
            frmMain.Content = page;
        }



        #endregion

    }
}
