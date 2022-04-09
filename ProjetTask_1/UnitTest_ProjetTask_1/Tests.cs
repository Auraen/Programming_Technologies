using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetTask_1.LogicLayer;
using System;

namespace UnitTest_ProjetTask_1
{
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
    
    [TestClass]
    public class Tests
    {
        BusinessLogicAPI? API;
        
        [TestInitialize]
        public void TestInitialize()
        {
            API = new BusinessLogicAPI(new DataAPI());
        }

        public void GenerateData_noDuplicate()
        {
            API.service.AddUser("John", "Doe");
            API.service.AddUser("Jane", "Doe");
            API.service.AddUser("Jack", "Doe");
            API.service.AddUser("Jill", "Doe");
            API.service.AddUser("Joe", "Doe");


            API.service.AddBook("Victor Hugo", "Les Misérables");
            API.service.AddBook("Victor Hugo", "Le Petit Prince");
            API.service.AddBook("Stendhal", "Le Comte de Monte Cristo");
            API.service.AddBook("Shakespeare", "Hamlet");
            API.service.AddBook("Shakespeare", "Romeo et Juliette");
        }
        public void GenerateData_severalBook()
        {
            API.service.AddUser("John", "Doe");
            API.service.AddUser("Jane", "Doe");
            API.service.AddUser("Jack", "Doe");
            API.service.AddUser("Jill", "Doe");
            API.service.AddUser("Joe", "Doe");

            API.service.AddBook("Shakespeare", "Hamlet");
            API.service.AddBook("Shakespeare", "Romeo et Juliette");
            API.service.AddBook("Shakespeare", "Romeo et Juliette");
            API.service.AddBook("Shakespeare", "Romeo et Juliette");
            API.service.AddBook("Victor Hugo", "Les Misérables");
            API.service.AddBook("Victor Hugo", "Les Misérables");
            API.service.AddBook("Victor Hugo", "Les Misérables");
            API.service.AddBook("Victor Hugo", "Les Misérables");
            API.service.AddBook("Victor Hugo", "Le Petit Prince");
            API.service.AddBook("Stendhal", "Le Comte de Monte Cristo");
            API.service.AddBook("Stendhal", "Le Comte de Monte Cristo");
        }

        [TestMethod]
        public void Should_add_the_correct_number_of_data()
        {
            GenerateData_severalBook();
            Assert.AreEqual(5, API.service.getNbUser());
            Assert.AreEqual(11, API.service.getNbBook());
        }

        [TestMethod]
        public void Should_change_the_availability()
        {
            GenerateData_noDuplicate();
            API.service.BorrowBook("Shakespeare", "Hamlet", "Jane", "Doe");
            Assert.IsFalse(API.service.getAvailability("Shakespeare", "Hamlet"));
        }

        [TestMethod]
        public void Should_not_change_the_availability()
        {
            GenerateData_noDuplicate();
            API.service.BorrowBook("Shakespeare", "Hamlet", "Jane", "Doe");
            API.service.ReturnBook("Shakespeare", "Hamlet", "Jane", "Doe");
            Assert.IsTrue(API.service.getAvailability("Shakespeare", "Hamlet"));
        }

        [TestMethod]
        public void Should_throw_UserNotFound_Exception()
        {
            GenerateData_severalBook();
            
            Assert.ThrowsException<AssertFailedException>(() => API.service.BorrowBook("Shakespeare", "Hamlet", "John", "Smith"), "User not found");
        }

        [TestMethod]
        public void Should_throw_BookNotFound_Exception()
        {
            GenerateData_severalBook();

            Assert.ThrowsException<AssertFailedException>(() => API.service.BorrowBook("Shakespeare", "Macbeth", "John", "Smith"), "Book not found");
        }

    }
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
}
