using EmployeeApp;
using EmployeeApp.Contracts;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace NUnitTestEmployee
{
    public class EmployeeExportTests
    {
        public const string FIRSTNAME = "First Name";
        public const string MIDDLEINITIAL = "Middle Initial";
        public const string LASTNAME = "Last Name";
        public const string CITY = "City";
        public const string STATE = "State";
        public const string ZIP = "Zip";
        public const int ID = 1;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDelimiterHeader()
        {
            // Arrange
            var expectedResult = "First Name|Middle Initial|Last Name|City|State|Zip|Bonus";
            var fileName = @"d:\employee.txt";
            var employees = new List<Employee>();
            var manager = new EmployeeManager();
            employees.Add(new Employee
            {
                FirstName = FIRSTNAME,
                LastName = LASTNAME,
                City = CITY,
                Zip = ZIP,
                MiddleInitial = MIDDLEINITIAL,
                State = STATE,
                Id = ID
            });

            // Act
            manager.ExportFile(employees, FileTypeEnum.DELIMITED);
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                line = reader.ReadLine();
            }

            // Assert
            Assert.AreEqual(expectedResult, line);
        }

        [Test]
        public void TestCSVHeader()
        {
            var expectedResult = "First Name,Middle Initial,Last Name,City,State,Zip,Bonus";
            var fileName = @"d:\employee.csv";
            var employees = new List<Employee>();
            var manager = new EmployeeManager();
            employees.Add(new Employee
            {
                FirstName = FIRSTNAME,
                LastName = LASTNAME,
                City = CITY,
                Zip = ZIP,
                MiddleInitial = MIDDLEINITIAL,
                State = STATE,
                Id = ID
            });

            manager.ExportFile(employees, FileTypeEnum.CSV);
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                line = reader.ReadLine();
            }

            Assert.AreEqual(expectedResult, line);
        }

        [Test]
        public void TestJsonFile()
        {
            var expectedResult = "[{\"Id\":1,\"MiddleInitial\":\"Middle Initial\",\"FirstName\":\"First Name\",\"LastName\":\"Last Name\",\"City\":\"City\",\"State\":\"State\",\"Country\":null,\"Zip\":\"Zip\",\"Bonus\":0}]";
            var fileName = @"d:\employee.json";
            var employees = new List<Employee>();
            var manager = new EmployeeManager();
            employees.Add(new Employee
            {
                FirstName = FIRSTNAME,
                LastName = LASTNAME,
                City = CITY,
                Zip = ZIP,
                MiddleInitial = MIDDLEINITIAL,
                State = STATE,
                Id = ID
            });

            manager.ExportFile(employees, FileTypeEnum.JSON);
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                line = reader.ReadLine();
            }

            Assert.AreEqual(expectedResult, line);
        }

        [Test]
        public void TestBonus()
        {
            // Arrange
            var expectedResult = "First Name,Last Name,City,State,Zip,30,";
            var fileName = @"d:\employee.csv";
            var employees = new List<Employee>();
            var manager = new EmployeeManager();
            for (int i = 1; i <= 202; i++)
            {
                employees.Add(new Employee
                {
                    FirstName = FIRSTNAME,
                    LastName = LASTNAME,
                    City = CITY,
                    Zip = ZIP,
                    MiddleInitial = MIDDLEINITIAL,
                    State = STATE,
                    Id = i
                });
            }

            // Act
            manager.ExportFile(employees, FileTypeEnum.CSV);
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                for (int i = 0; i <= 3; i++)
                    line = reader.ReadLine();
            }

            // Assert
            Assert.AreEqual(expectedResult, line);
        }


    }
}