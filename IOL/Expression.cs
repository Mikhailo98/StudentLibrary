using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IOL
{

    /// <summary>
    /// In this class there regular expressions which check input data for specified rules
    /// </summary>
    class Expression
    {
       public static string ReadBookName()
        {
            return ReadString("Book Name", "Aplhabet", @"\D");

       }
        public static string ReadName()
        {
            return ReadString("name", "John", @"\b[A-Z][a-z]+\b");
        }
        public static string ReadSurname()
        {
            return ReadString("surname", "Smith", @"\b[A-Z][a-z]+\b");
        }

        public static string ReadDate()
        {
            return ReadString("date", "27/01/2014", @"(0[1-9]|[12][0-9]|3[01])[\/.](0[1-9]|1[012])[\/.](19|20)\d\d");
        }

        public static string ReadStudentId()
        {
            return ReadString("Student ID", "KB-41197842", @"^([A-ZА-Я]{2})-\d{8}$");
        }
        public static int ReadCourse()
        {
            return ReadInt("Course");
        }
        public static string ReadGroup()
        {
            return ReadString("Academic Group", "SE-123", @"^([A-Z]{2})-\d{3}$");
        }

        private static int ReadInt(string s)
        {
            Console.Write("Enter " + s + ": ");
            int i;
            if (int.TryParse(Console.ReadLine(), out i))
            {
                return i;
            }
            else
            {
                throw new FormatException("Invalid number!");
            }
        }
        private static string ReadString(string name, string ex, string regex)
        {
            Console.Write("Enter " + name + " (Example: " + ex + "): ");
            string s = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(s))
            {
             
                throw new FormatException(char.ToUpper(name[0]) + name.Substring(1) + " can't be empty!");
            }
            else if (Regex.IsMatch(s, regex))
            {
                return s;
            }
            else
            {
                throw new FormatException("Invalid " + name + "!");
            }
        }
    }
}
