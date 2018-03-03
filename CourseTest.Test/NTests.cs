using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BLL;
using IOL;
namespace CourseTest.Test
{
    [TestFixture]
    public class NTests
    {      


        [Test]
        public void AddandGetBook()
        {

            //arrange 
            Logic l = new Logic();
            //act       
            l.AddBook("OOP", "Richter", "Jefrey");
            string get = l.FindBookByName("OOP");            
            //assert
            Assert.AreEqual(get, "Name: OOP          Author: Richter Jefrey  Owner: Library");
        }



        [Test]
        public void AddandRemoveBook()
        {

            //arrange 
            Logic l = new Logic();
            bool expected = true;            
            //act       
            l.AddBook("OOP", "Richter", "Jefrey");
            bool value = l.RemoveBook("OOP");            
            //assert
            Assert.AreEqual(value, expected);
        }
      


        [Test]
        public void AddandGetUser()
        {

            //arrange 
            Logic l = new Logic();
            //act       
            l.AddUser("Mike", "Kovalchuk", "KB12345678", 2 , "25/12/2000", "SE-217");
            User value = l.EditViewUser("KB12345678");
            //assert
            Assert.AreNotEqual(value, null);
        }


    
    }
}
