using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLib;
using System;

namespace StudentLib.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CheckName_ValidName_ReturnsTrue()
        {
            var student = new Student("Anna1", "Smith", new DateTime(2000, 1, 1), 2, "Computer Science");
            Assert.IsTrue(student.CheckName());
        }

        [TestMethod]
        public void CheckName_WithoutDigit_ReturnsFalse()
        {
            var student = new Student("Anna", "Smith", new DateTime(2000, 1, 1), 2, "Math");
            Assert.IsFalse(student.CheckName());
        }
        
        [TestMethod]
        public void CheckName_WithoutDigit_ReturnsTrue()
        {
            var student = new Student("Ilya1", "Prokofev", new DateTime(2000, 1, 1), 2, "CS");
            Assert.IsTrue(student.CheckName());
        }
        

        [TestMethod]
        public void CheckName_MoreThanOneDigit_ReturnsFalse()
        {
            var student = new Student("Ann1a2", "Doe", new DateTime(2000, 1, 1), 2, "Physics");
            Assert.IsFalse(student.CheckName());
        }

        [TestMethod]
        public void TransformSpecialty_RemovesExtraSpacesAndToUpper()
        {
            var student = new Student("John", "Doe", new DateTime(2000, 1, 1), 3, "   Software     Engineering   ");
            string result = student.TransformSpecialty();

            Assert.AreEqual("SOFTWARE ENGINEERING", result);
            Assert.AreEqual("SOFTWARE ENGINEERING", student.Specialty);
        }

        [TestMethod]
        public void CheckBirthday_FutureDate_ReturnsMinusOne()
        {
            var student = new Student("Test", "User", new DateTime(2100, 1, 1), 1, "Biology");
            Assert.AreEqual(-1, student.CheckBirthday());
        }

        [TestMethod]
        public void CheckBirthday_Teenager_ReturnsOne()
        {
            var student = new Student("Alice", "Brown", DateTime.Now.AddYears(-17), 1, "Chemistry");
            Assert.AreEqual(1, student.CheckBirthday());
        }

        [TestMethod]
        public void CheckBirthday_Adult_ReturnsTwo()
        {
            var student = new Student("Bob", "Taylor", DateTime.Now.AddYears(-20), 3, "History");
            Assert.AreEqual(2, student.CheckBirthday());
        }
    }
}