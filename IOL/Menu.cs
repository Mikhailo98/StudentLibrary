using System;
using System.Configuration;
using BLL;
using System.IO;
using System.Threading;

namespace IOL
{


    /// <summary>
    /// Here program interacts with the user due to console
    /// </summary>
    public class Menu
    {
        private const string Separator = "--------------------------------------------------------------------------\n";
        private string Input;
        private Handle<User> userHandle;
        private Handle<Book> bookHandle;
        private User tempUser;
        private Book tempBook;

        Logic logic = new Logic();


        public Menu()
        {
            

        }


       
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(Separator +
                   "Library for Students \n" +
                   "Main menu\n" +
                   Separator +
                   "Choose one of the following options:\n" +
                   "1 - Users\n" +
                   "2 - Books\n" +
                   "3 - Operate\n" +
                   "4 - Save Data\n" +
                   "5 - Help\n" +
                   "6 - Exit\n" +
                   Separator);
                Input = Console.ReadLine().Trim();
                switch (Input)
                {
                    case "1":
                        Wrapper(UserSubmenu);
                        break;
                    case "2":
                        Wrapper(BookSubmenu);
                        break;
                    case "3":
                        Wrapper(OperationSubmenu);
                        break;
                    case "4":
                        Wrapper(SaveSubmenu);
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            }
        }

        private bool SaveSubmenu()
        {

            logic.SaveItems();
            Console.WriteLine("Items were successfully saved!");
            Console.ReadKey();
            return true;
        }


        private bool OperationSubmenu()
        {

            Console.Clear();
            Console.Write(Separator +
                "Operation submenu\n" +
                Separator +
               "Choose one of the following options:\n" +
                "1 - Give Book\n" +
                "2 - Return Book\n" +
                "3 - Watch current owner\n" +
                "4 - Return back to menu\n" +
                Separator);
            Input = Console.ReadLine();
            switch (Input)
            {
                case "1":
                    if (logic.GiveBook(Expression.ReadStudentId(),
                        Expression.ReadBookName()) == true)
                        Console.WriteLine("Operation is successful!");

                    break;
                case "2":
                    if (logic.ReturnBook(Expression.ReadStudentId(),
                           Expression.ReadBookName()))
                        Console.WriteLine("Operation is successful");
                    break;
                case "3":
                    Console.WriteLine(logic.WatchOwner(Expression.ReadBookName()));
                    Console.ReadKey();
                    break;
                case "4":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A wrapper of submenus, which accepts a Func type delegate
        /// all exceptions are catched here for continuing program wok
        /// </summary>
        /// <param name="a"> A method that returns boolean value</param>
        private void Wrapper(Func<bool> a)
        {
            bool b = false;
            while (!b)
            {
                try
                {
                    b = a();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message +
                        "\nPress enter to continue");
                    Console.ReadLine();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Entered index is out of range!\n" +
                        "Press enter to continue");
                    Console.ReadLine();
                }
            }
        }


        #region Book Operation


        private bool BookSubmenu()
        {
            Console.Clear();
            Console.Write(Separator +
                "User submenu\n" +
                Separator +
               "Choose one of the following options:\n" +
                "\t 1 - Add Book \n" +
                "\t 2 - Remove Book\n" +
                "\t 3 - View\\Edit Book\n" +
                "\t 4 - Find Book by Name\n" +
                "\t 5 - Show all Books \n" +
                "\t 6 - Sort Books by Name \n" +
                "\t 7 - Sort Books by Author \n" +
                "\t 8 - Show Book Owner Info \n" +
                "\t 9 - Return back to main menu\n" +
                Separator);
            Input = Console.ReadLine().Trim();
            Console.WriteLine();
            switch (Input)
            {
                case "1":
                    logic.AddBook(
                            Expression.ReadBookName(),
                            Expression.ReadName(),
                            Expression.ReadSurname());
                    break;
                case "2":
                    if (logic.RemoveBook(Expression.ReadBookName()))
                        Console.WriteLine("Operation is successful");
                    break;

                case "3":
                    if (logic.EditViewBook(Expression.ReadBookName()))
                        EditViewBookSubmenu();
                    break;

                case "4":
                    Console.WriteLine(logic.FindBookByName(Expression.ReadBookName()));
                    break;
                case "5":
                    Console.WriteLine(logic.ShowAll());
                    break;
                case "6":
                    logic.SortBookByName();
                    break;
                case "7":
                    logic.SortBookByAuthor();
                    break;
                case "8":
                    Console.WriteLine(logic.ShowBookOwner(Expression.ReadBookName()));
                    break;
                case "9":
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.ReadKey();
            return false;
        }

        private bool EditViewBookSubmenu()
        {
            Console.Clear();
            Console.Write(Separator +
                "View\\Edit Book submenu\n" +
                Separator +
                tempBook.ToString() + '\n' +
                Separator +
                "Choose one of the following options:\n" +
                "1 - Change Book Name \n" +
                "2 - Change Author Name\n" +
                "3 - Change Author Surname\n" +
                "7 - Return back to \"Books\" submenu\n" +
                Separator);

            Input = Console.ReadLine().Trim();
            if (Input == "7")
            {
                return true;
            }
            switch (Input)
            {
                case "1":
                    tempBook.Name = Expression.ReadName();
                    break;
                case "2":
                    tempBook.AuthorName = Expression.ReadName();
                    break;
                case "3":
                    tempBook.AuthorSurname = Expression.ReadSurname();
                    break;
                case "7":
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return false;

        }
        #endregion


        #region User Operation
        private bool UserSubmenu()
        {
            Console.Clear();
            Console.Write(Separator +
                "User submenu\n" +
                Separator +
                "Choose one of the following options:\n" +
                "\t 1 - Add User \n" +
                "\t 2 - Remove User\n" +
                "\t 3 - View\\Edit User\n" +
                "\t 4 - Get User info \n" +
                "\t 5 - Show all Students \n" +
                "\t 6 - Sort by Student ID \n" +
                "\t 7 - Sort by Name \n" +
                "\t 8 - Sort by Surname \n" +
                "\t 9 - Sort by Academic Group \n" +
                "\t10 - Return back to main menu\n" +
                Separator);
            Input = Console.ReadLine();
            switch (Input)
            {
                case "1":
                    logic.AddUser(Expression.ReadName(),
                        Expression.ReadSurname(),
                        Expression.ReadStudentId(),
                        Expression.ReadCourse(),
                        Expression.ReadDate(),
                        Expression.ReadGroup());
                    break;
                case "2":

                    if (logic.RemoveUser(Expression.ReadStudentId()))
                        Console.WriteLine("Student was deleted");
                    break;

                case "3":
                    tempUser = logic.EditViewUser(Expression.ReadStudentId());
                    EditViewUserSubmenu();
                    break;

                case "4":
                    Console.WriteLine(logic.InfoGet(Expression.ReadSurname(),
                  Expression.ReadGroup()));
                    Console.ReadKey();
                    break;

                case "5":
                    Console.WriteLine(logic.ShowAllUsers());
                    Console.ReadKey();
                    break;
                case "6":
                    logic.SortUserByID();
                    break;
                case "7":
                    logic.SortUserByName();
                    break;
                case "8":
                    logic.SortUserBySurname();
                    break;
                case "9":
                    logic.SortUserByGroup();
                    break;
                case "10":
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();

            }

            return false;

        }

        private bool EditViewUserSubmenu()
        {
            Console.Clear();
            Console.Write(Separator +
                "View\\Edit User submenu\n" +
                Separator +
                tempUser.ToString() + '\n' +
                Separator +
                "Choose one of the following options:\n" +
                "1 - Change Name \n" +
                "2 - Change Surname\n" +
                "3 - Change Student ID\n" +
                "4 - Change Course\n" +
                "5 - Change Date of Birth\n" +
                "6 - Change Academic Group \n" +
                "7 - Return back to \" submenu\n" +
                Separator);

            Input = Console.ReadLine().Trim();
            if (Input == "7")
            {
                return true;
            }
            switch (Input)
            {
                case "1":
                    tempUser.Name = Expression.ReadName();
                    break;
                case "2":
                    tempUser.Surname = Expression.ReadSurname();
                    break;
                case "3":
                    tempUser.StudentID = Expression.ReadStudentId();
                    break;
                case "4":
                    tempUser.Course = Expression.ReadCourse();
                    break;
                case "5":
                    tempUser.BirthDate = Expression.ReadDate();
                    break;
                case "6":
                    tempUser.AcademGroup = Expression.ReadGroup();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;
            }

            return false;

        }
        #endregion



       

    }
}
