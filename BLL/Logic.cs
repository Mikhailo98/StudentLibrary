using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     /// <summary>
     /// Class is responsible for business logic of the project 
     /// </summary>
    public class Logic
    {
        private Handle<User> userHandle;
        private Handle<Book> bookHandle;

        private readonly string userPath;
        private readonly string bookPath;

        private User tempUser;
        private Book tempBook;


        public Logic()
        {

            userPath = @"K:\User.dat";
            bookPath = @"K:\Book.dat";


            userHandle = new Handle<User>(userPath);
            bookHandle = new Handle<Book>(bookPath);
           
        }



        #region Operate

        /// <summary>
        /// Method gives specific book either there is exception
        /// </summary>
        /// <param name="Input">Is Student Id</param>
        /// <param name="Input2">Name of the Book</param>
        /// <returns>returns boolean value if operation done successfully either not</returns>
        public bool GiveBook(string Input, string Input2)
        {
            tempUser = userHandle.Find((item) =>
                             {
                                 return (item.StudentID == Input) ? true : false;
                             });
            if (tempUser != null)
            {
                tempBook = bookHandle.Find((item) =>
                {
                    return (item.Name == Input2) ? true : false;
                });
                if (tempBook != null && tempBook.Available == true && tempUser.bookList.Count < 5)
                {
                    tempBook.Owner = tempUser;
                    tempBook.Available = false;
                    tempUser.bookList.Add(tempBook);
                    return true;
                }
                throw new FormatException("There is not any book you want");
            }
            throw new FormatException("Invalid ID");
        }


        /// <summary>
        /// Returns a Book 
        /// </summary>
        /// <param name="Input">Is Student Id</param>
        /// <param name="Input2">Name of the Book</param>
        /// <returns>returns boolean value if operation done successfully either not</returns>
        public bool ReturnBook(string Input, string Input2)
        {
            tempUser = userHandle.Find(((item) =>
            {
                return (item.StudentID == Input) ? true : false;
            }
            )) ?? throw new FormatException("Invalid ID");

            tempBook = bookHandle.Find((item) =>
            {
                return (item.Name == Input2) ? true : false;
            }) ?? throw new FormatException("There is not any book you want");
            if (tempBook.Available == true)
            {
                tempBook.Owner = null;
                tempBook.Available = true;
                tempUser.bookList.Remove(tempBook);
                return true;
            }
            return false;
        }


        /// <summary>
        /// You can watch current owner of a Book
        /// </summary>
        /// <param name="Input">Book name</param>
        /// <returns>Returns a string value of ovner</returns>
        public string WatchOwner(string Input)
        {
            tempBook = bookHandle.Find((item) =>
            {
                return (item.Name == Input) ? true : false;
            }) ?? throw new FormatException("There is not any book you want");
            return tempBook.Owner?.Details() ?? "There is not any Owner";
        }


        #endregion
        #region Book


        /// <summary>
        /// Adds Book to Library
        /// </summary>
        /// <param name="BookName">Name of a book</param>
        /// <param name="Name">Name of a Author</param>
        /// <param name="Surname">Surname of a Author</param>
        public void AddBook(string BookName, string Name, string Surname)
        {
            bookHandle.Add(new Book(BookName, Name, Surname));
        }


        /// <summary>
        /// Removes Book from Library
        /// </summary>
        /// <param name="BookName">Book name</param>
        /// <returns>Return Boolean Value</returns>
        public bool RemoveBook(string BookName)
        {
            tempBook = bookHandle.Find((item) =>
            {
                return (item.Name == BookName && item.Available == true) ? true : false;

            }) ?? throw new FormatException("Book Absence!");
            bookHandle.Remove(tempBook);
            return true;
        }


        /// <summary>
        /// Shows if book by specified name exists
        /// </summary>
        /// <param name="BookName">Name of Book</param>
        /// <returns></returns>
        public bool EditViewBook(string BookName)
        {
            tempBook = bookHandle.Find((item) =>
            {
                return (item.Name == BookName) ? true : false;

            }) ?? throw new FormatException("Book Absence!");
            return true;

        }


        /// <summary>
        /// Shows Book details
        /// </summary>
        /// <param name="BookName">Book Name</param>
        /// <returns></returns>
        public string FindBookByName(string BookName)
        {
            return bookHandle.Find((item) =>
             {
                 return (item.Name == BookName) ? true : false;

             })?.ToString() ?? throw new FormatException(("Invalid Book!"));
        }

     

        public string ShowAll()
        {
            return bookHandle.ToString();
        }

        public void SortBookByName()
        {
            bookHandle.Sort((a, b) => a.Name.CompareTo(b.Name));
        }

        public void SortBookByAuthor()
        {
            bookHandle.Sort((a, b) => a.AuthorSurname.CompareTo(b.AuthorSurname));
        }

        /// <summary>
        /// Shows details about Owner
        /// </summary>
        /// <param name="BookName"></param>
        /// <returns></returns>
        public string ShowBookOwner(string BookName)
        {

            var j = bookHandle.Find((item) =>
                  {
                      return (item.Name == BookName) ? true : false;

                  }) ?? throw new FormatException("Book Absence!");

            return j.Owner?.Details() ?? throw new FormatException("Book has not Owner");
        }
        #endregion
        #region User

        /// <summary>
        /// Adds a User to Library database
        /// </summary>
        public void AddUser(string Name, string Surname, string StudentID,
           int Course, string Date, string Group)
        {
            userHandle.Add(new User(Name, Surname, StudentID, Course, Date, Group));
        }


        /// <summary>
        /// Removes User from Library database
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public bool RemoveUser(string Input)
        {
            tempUser = userHandle.Find(((item) =>
            {
                return (item.StudentID == Input) ? true : false;
            })) ?? throw new FormatException("Invalid ID");

            userHandle.Remove(tempUser);
            return true;
        }


        /// <summary>
        /// Gets Inforamation about specific User 
        /// </summary>
        /// <param name="surname">User Surname</param>
        /// <param name="group">User Gruop</param>
        public string InfoGet(string surname, string group)
        {
            tempUser = userHandle.Find((item) =>
            {
                if (item.Surname == surname
                && item.AcademGroup == group)
                    return true;
                else
                    return false;
            });
            return tempUser?.Details() ?? throw new FormatException("Invalid request");

        }

        public string ShowAllUsers()
        {
            return userHandle.ToString();
        }

        public void SortUserByID()
        {
            userHandle.Sort((a, b) => a.StudentID.CompareTo(b.StudentID));
        }

        public void SortUserByName()
        {
            userHandle.Sort((a, b) => a.Name.CompareTo(b.Name));
        }

        public void SortUserBySurname()
        {
            userHandle.Sort((a, b) => a.Surname.CompareTo(b.Surname));
        }

        public void SortUserByGroup()
        {
            userHandle.Sort((a, b) => a.AcademGroup.CompareTo(b.AcademGroup));
        }


        /// <summary>
        /// Returns a Specific User if he exists
        /// </summary>
        /// <param name="Input">Student Id</param>
        /// <returns></returns>
        public User EditViewUser(string Input)
        {
            return tempUser = userHandle.Find(((item) =>
            {
                return (item.StudentID == Input) ? true : false;
            })) ?? throw new FormatException("Invalid ID");
             
        }
        #endregion
        #region Save

        /// <summary>
        /// Saves all information in database
        /// </summary>
        public void SaveItems()
        {
            userHandle.Serialize();
            bookHandle.Serialize();
        }
        #endregion
    }
}
