using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentID { get; set; }
        public int Course { get; set; }
        public string BirthDate { get; set; }
        public string AcademGroup { get; set; }
        public List<Book> bookList;

        public User()
        {

        }


        public string NameSurname()
        {
            return string.Format($"{Name} {Surname}");
        }

        public User(string Name, string Surname, string StudentID,
            int Course, string BirthDate, string AcademGroup)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.StudentID = StudentID;
            this.Course = Course;
            this.BirthDate = BirthDate;
            this.AcademGroup = AcademGroup;
            bookList = new List<Book>();

        }

        public override string ToString()
        {
            return string.Format("Name: {0,-12} Surname: {1,-15} Academic Group: {2,-7}",
                Name, Surname, AcademGroup);
        }
        public string Details()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" Name: {this.Name}");
            sb.AppendLine($" Surname: {this.Surname}");
            sb.AppendLine($" Student ID: {this.StudentID}");
            sb.AppendLine($" Course: {this.Course}");
            sb.AppendLine($" Birth Date: {this.BirthDate}");
            sb.AppendLine($" Academic Group: {this.AcademGroup}");
            sb.AppendLine($" Books: ");
            if (bookList.Count == 0)
                sb.AppendLine("Empty");
            else
                foreach (var item in bookList)
                    sb.AppendLine(item.ToString());
            return sb.ToString();



        }
    }
}
