using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BooksLibraryDB.Model
{
    public class DBUtils
    {
        #region Calculation Number Of Loans
        public static int getLoansNumber(int bookId)
        {
            int loanNumber = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spCountLoans";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@BookId", SqlDbType.Int);
                    command.Parameters["@BookId"].Value = bookId;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    loanNumber = (int)command.ExecuteScalar();
                }
            }
            return loanNumber;
        }
        #endregion

        #region Add Methods To DB
        public static bool addAuthor(Author aut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spAuthorInsert"; 
                SqlCommand command = new SqlCommand(commandText, connection); 
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar); 
                command.Parameters["@FirstName"].Value = aut.firstname; 
                command.Parameters.Add("@LastName", SqlDbType.NVarChar); 
                command.Parameters["@LastName"].Value = aut.lastName;
                command.Parameters.Add("@BirthDate", SqlDbType.Date);
                command.Parameters["@BirthDate"].Value = aut.birthDate;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool addAuthorBook(AuthorBook authorBook)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spAuthorBookInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AuthorId", SqlDbType.Int);
                command.Parameters["@AuthorId"].Value = authorBook.authorId;
                command.Parameters.Add("@BookId", SqlDbType.Int);
                command.Parameters["@BookId"].Value = authorBook.bookId;
                command.Parameters.Add("@NumberInList", SqlDbType.Int);
                command.Parameters["@NumberInList"].Value = authorBook.numberInList;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool addPublisher(Publisher publisher)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spPublisherInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = publisher.name;
                command.Parameters.Add("@Adress", SqlDbType.VarChar);
                command.Parameters["@Adress"].Value = publisher.adress;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool addBookType(BookType bt)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookTypeInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = bt.name;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool addBook(Book book)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookTypeId", SqlDbType.Int);
                command.Parameters["@BookTypeId"].Value = book.bookTypeId;
                command.Parameters.Add("@PublisherId", SqlDbType.Int);
                command.Parameters["@PublisherId"].Value = book.publisherId;
                command.Parameters.Add("@Title", SqlDbType.NVarChar);
                command.Parameters["@Title"].Value = book.title;
                command.Parameters.Add("@PublisherYear", SqlDbType.Int);
                command.Parameters["@PublisherYear"].Value = book.publishYear;
                command.Parameters.Add("@Stock", SqlDbType.Int);
                command.Parameters["@Stock"].Value = book.stock;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool addUser(User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                command.Parameters["@FirstName"].Value = user.firstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar);
                command.Parameters["@LastName"].Value = user.lastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar);
                command.Parameters["@Email"].Value = user.email;
                command.Parameters.Add("@Phone", SqlDbType.VarChar);
                command.Parameters["@Phone"].Value = user.phone;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool addUserBook(UserBook ub)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserBookInsert";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserId", SqlDbType.Int);
                command.Parameters["@UserId"].Value = ub.userId;
                command.Parameters.Add("@BookId", SqlDbType.Int);
                command.Parameters["@BookId"].Value = ub.bookId;
                command.Parameters.Add("@StartDate", SqlDbType.Date);
                command.Parameters["@StartDate"].Value = ub.startDate;
                command.Parameters.Add("@ReturnDate", SqlDbType.Date);
                command.Parameters["@ReturnDate"].Value = ub.returnDate;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }
        #endregion

        #region Get Lists From DB
        public static ObservableCollection<Author> getAuthorList()
        {
            ObservableCollection<Author> authorList = new ObservableCollection<Author>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spAuthorSelect";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tempId = (int)reader["AuthorId"];
                            String tempFirstName = reader["FirstName"].ToString();
                            String tempLastName = reader["LastName"].ToString();
                            String tempBirthDate = reader["BirthDate"].ToString();
                            bool tempIsActive = (bool)reader["Active"];
                            Author author = new Author(tempId, tempFirstName, tempLastName, tempBirthDate, tempIsActive);
                            authorList.Add(author);
                        }
                    }
                }
            }
            return authorList;
        }

        public static ObservableCollection<User> getUserList()
        {
            ObservableCollection<User> userList = new ObservableCollection<User>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserSelect";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tempId = (int)reader["UserId"];
                            String tempFirstName = reader["FirstName"].ToString();
                            String tempLastName = reader["LastName"].ToString();
                            String tempEmail = reader["Email"].ToString();
                            String tempPhone = reader["Phone"].ToString();
                            bool tempIsActive = (bool)reader["Active"];
                            User user = new User(tempId, tempFirstName, tempLastName, tempEmail, tempPhone, tempIsActive);
                            userList.Add(user);
                        }
                    }
                }
            }
            return userList;
        }

        public static ObservableCollection<Publisher> getPublisherList()
        {
            ObservableCollection<Publisher> publisherList = new ObservableCollection<Publisher>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spPublisherSelect";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tempId = (int)reader["PublisherId"];
                            String tempName = reader["PublisherName"].ToString();
                            String adress = reader["Adress"].ToString();
                            bool tempIsActive = (bool)reader["Activ"];
                            Publisher publisher = new Publisher(tempId, tempName, adress, tempIsActive);
                            publisherList.Add(publisher);
                        }
                    }
                }
            }
            return publisherList;
        }

        public static ObservableCollection<ResumeTable> getBookList()
        {
            ObservableCollection<ResumeTable> bookList = new ObservableCollection<ResumeTable>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookSelect";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tempId = (int)reader["BookId"];
                            string tempTitle = reader["Title"].ToString();
                            string tempTypeTitle = reader["Name"].ToString();
                            string tempPublisherIName = reader["PublisherName"].ToString();                          
                            int publishYear = (int)reader["PublishYear"];
                            int stock = (int)reader["Stock"];
                            string tempAuthorFirstName = reader["FirstName"].ToString();
                            string tempAuthorLastName = reader["LastName"].ToString();

                            ResumeTable book = new ResumeTable(tempId, tempTitle, tempTypeTitle, tempPublisherIName, publishYear, stock, tempAuthorFirstName, tempAuthorLastName);
                            bookList.Add(book);
                        }
                    }
                }
            }
            return bookList;
        }

        public static ObservableCollection<BookType> getBookTypeList()
        {
            ObservableCollection<BookType> bookTypeList = new ObservableCollection<BookType>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookTypeSelect";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tempId = (int)reader["BookTypeId"];
                            String tempName = reader["Name"].ToString();
                            bool tempIsActive = (bool)reader["Active"];
                            BookType bookType = new BookType(tempId,  tempName, tempIsActive);
                            bookTypeList.Add(bookType);
                        }
                    }
                }
            }
            return bookTypeList;
        }

        public static ObservableCollection<ResumeLoanTable> getLoansList()
        {
            ObservableCollection<ResumeLoanTable> loansList = new ObservableCollection<ResumeLoanTable>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserBookSelect";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tempId = (int)reader["Id"];
                            String tempFirstName = reader["FirstName"].ToString();
                            String tempLastName = reader["LastName"].ToString();
                            String tempTitle = reader["Title"].ToString();
                            String tempStartDate= reader["StartDate"].ToString();
                            String tempReturnDate = reader["ReturnDate"].ToString();

                            ResumeLoanTable loan = new ResumeLoanTable(tempId ,tempFirstName, tempLastName, tempTitle, tempStartDate, tempReturnDate);
                            loansList.Add(loan);
                        }
                    }
                }
            }
            return loansList;
        }
        #endregion

        #region Get Selected Objects From DB

        public static List<Book> getSelectedBook(int id)
        {
            List<Book> bookList = new List<Book>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookSelectById";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@BookId", SqlDbType.Int);
                    command.Parameters["@BookId"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bookId = (int)reader["BookId"];
                            int bookTypeId = (int)reader["BookTypeId"];
                            int publisherId = (int)reader["PublisherId"];
                            string title = reader["Title"].ToString();
                            int publishYear = (int)reader["PublishYear"];
                            int stock = (int)reader["Stock"];
                            bool isActive = (bool)reader["Active"];

                            Book book = new Book(bookId, bookTypeId, publisherId, title, publishYear, stock, isActive);
                            bookList.Add(book);
                        }
                    }
                }
            }
            return bookList;
        }

        public static List<UserBook> getSelectedUserBook(int id)
        {
            List<UserBook> loanList = new List<UserBook>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserBookSelectById";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int loanId = (int)reader["Id"];
                            int userId = (int)reader["UserId"];
                            int bookId = (int)reader["BookId"];
                            string startDate = reader["StartDate"].ToString();
                            string returnDate = reader["ReturnDate"].ToString();

                            UserBook loan = new UserBook(loanId, userId, bookId, startDate, returnDate);
                            loanList.Add(loan);
                        }
                    }
                }
            }
            return loanList;
        }


        public static List<Publisher> getSelectedPublisher(int id)
        {
            List<Publisher> publisherList = new List<Publisher>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spPublisherSelectById";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@PublisherId", SqlDbType.Int);
                    command.Parameters["@PublisherId"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int publisherId = (int)reader["PublisherId"];
                            string name = reader["PublisherName"].ToString();
                            string adress = reader["Adress"].ToString();
                            bool isActive = (bool)reader["Activ"];

                            Publisher publisher = new Publisher(publisherId, name, adress, isActive);
                            publisherList.Add(publisher);
                        }
                    }
                }
            }
            return publisherList;
        }

        public static List<Author> getSelectedAuthor(int id)
        {
            List<Author> authorList = new List<Author>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spAuthorSelectById";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@AuthorId", SqlDbType.Int);
                    command.Parameters["@AuthorId"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int authorId = (int)reader["AuthorId"];
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string birthDate = reader["BirthDate"].ToString();
                            bool isActive = (bool)reader["Active"];

                            Author author = new Author(authorId, firstName, lastName, birthDate, isActive);
                            authorList.Add(author);
                        }
                    }
                }
            }
            return authorList;
        }

        public static List<BookType> getSelectedBookType(int id)
        {
            List<BookType> bookTypeList = new List<BookType>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookTypeSelectById";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@BookTypeId", SqlDbType.Int);
                    command.Parameters["@BookTypeId"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bookTypeId = (int)reader["BookTypeId"];
                            string name = reader["Name"].ToString();
                            bool isActive = (bool)reader["Active"];

                            BookType author = new BookType(bookTypeId, name, isActive);
                            bookTypeList.Add(author);
                        }
                    }
                }
            }
            return bookTypeList;
        }

        public static List<User> getSelectedUser(int id)
        {
            List<User> userList = new List<User>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserSelectById";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserId", SqlDbType.Int);
                    command.Parameters["@UserId"].Value = id;
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {; }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = (int)reader["UserId"];
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string email = reader["Email"].ToString();
                            string phone = reader["Phone"].ToString();
                            bool isActive = (bool)reader["Active"];

                            User user = new User(userId, firstName, lastName, email, phone, isActive);
                            userList.Add(user);
                        }
                    }
                }
            }
            return userList;
        }
        #endregion

        #region Edit Methods In DB
        public static bool editSelectedBook(Book b)
        {
            ObservableCollection<Book> bookList = new ObservableCollection<Book>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookEdit";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookId", SqlDbType.Int);
                command.Parameters["@BookId"].Value = b.bookId;
                command.Parameters.Add("@BookTypeId", SqlDbType.Int);
                command.Parameters["@BookTypeId"].Value = b.bookTypeId;
                command.Parameters.Add("@PublisherId", SqlDbType.Int);
                command.Parameters["@PublisherId"].Value = b.publisherId;
                command.Parameters.Add("@Title", SqlDbType.NVarChar);
                command.Parameters["@Title"].Value = b.title;
                command.Parameters.Add("@PublishYear", SqlDbType.Int);
                command.Parameters["@PublishYear"].Value = b.publishYear;
                command.Parameters.Add("@Stock", SqlDbType.Int);
                command.Parameters["@Stock"].Value = b.stock;
                command.Parameters.Add("@Active", SqlDbType.Bit);
                command.Parameters["@Active"].Value = b.isActive;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool editSelectedPublisher(Publisher p)
        {
            ObservableCollection<Publisher> publisherList = new ObservableCollection<Publisher>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spPublisherEdit";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PublisherId", SqlDbType.Int);
                command.Parameters["@PublisherId"].Value = p.publisherId;
                command.Parameters.Add("@PublisherName", SqlDbType.NVarChar);
                command.Parameters["@PublisherName"].Value = p.name;
                command.Parameters.Add("@Adress", SqlDbType.VarChar);
                command.Parameters["@Adress"].Value = p.adress;
                command.Parameters.Add("@Activ", SqlDbType.Bit);
                command.Parameters["@Activ"].Value = p.isActive;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool editSelectedAuthor(Author aut)
        {
            ObservableCollection<Author> publisherList = new ObservableCollection<Author>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spAuthorEdit";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AuthorId", SqlDbType.Int);
                command.Parameters["@AuthorId"].Value = aut.authorId;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                command.Parameters["@FirstName"].Value = aut.firstname;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar);
                command.Parameters["@LastName"].Value = aut.lastName;
                command.Parameters.Add("@BirthDate", SqlDbType.Date);
                command.Parameters["@BirthDate"].Value = aut.birthDate;
                command.Parameters.Add("@Active", SqlDbType.Bit);
                command.Parameters["@Active"].Value = aut.isActive;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool editSelectedBookType(BookType bt)
        {
            ObservableCollection<BookType> bookTypeList = new ObservableCollection<BookType>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spBookTypeEdit";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@BookTypeId", SqlDbType.Int);
                command.Parameters["@BookTypeId"].Value = bt.bookTypeId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = bt.name;
                command.Parameters.Add("@Active", SqlDbType.Bit);
                command.Parameters["@Active"].Value = bt.isActive;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool editSelectedUser(User user)
        {
            ObservableCollection<User> publisherList = new ObservableCollection<User>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserEdit";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserId", SqlDbType.Int);
                command.Parameters["@UserId"].Value = user.userId;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                command.Parameters["@FirstName"].Value = user.firstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar);
                command.Parameters["@LastName"].Value = user.lastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar);
                command.Parameters["@Email"].Value = user.email;
                command.Parameters.Add("@Phone", SqlDbType.VarChar);
                command.Parameters["@Phone"].Value = user.phone;
                command.Parameters.Add("@Active", SqlDbType.Bit);
                command.Parameters["@Active"].Value = user.isActive;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        public static bool editSelectedUserBook(UserBook ub)
        {
            ObservableCollection<UserBook> userBookList = new ObservableCollection<UserBook>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "spUserBookEdit";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = ub.loanId;
                command.Parameters.Add("@UserId", SqlDbType.Int);
                command.Parameters["@UserId"].Value = ub.userId;
                command.Parameters.Add("@BookId", SqlDbType.Int);
                command.Parameters["@BookId"].Value = ub.bookId;
                command.Parameters.Add("@StartDate", SqlDbType.Date);
                command.Parameters["@StartDate"].Value = ub.startDate;
                command.Parameters.Add("@returnDate", SqlDbType.Date);
                command.Parameters["@ReturnDate"].Value = ub.returnDate;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }
        #endregion
    }
}
