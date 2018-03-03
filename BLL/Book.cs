using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BLL
{
    [Serializable]
    public class Book
    {

        public string Name { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorName { get; set; }
        public bool Available { get; set; }
        public User Owner;

        public Book() { }
        public Book(string name, string authorname, string authorsurname)
        {
            Name = name;
            AuthorSurname = authorsurname;
            AuthorName = authorname;
            Available = true;
        }

        public override string ToString()
        {
            return string.Format("Name: {0,-12} Author: {1,-15} Owner: {2}",
                          Name, AuthorName + " " + AuthorSurname, Owner?.NameSurname() ?? "Library");
        }


    }
}
