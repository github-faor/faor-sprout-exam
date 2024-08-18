using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprout.Exam.Business.Services;
using Sprout.Exam.DataAccess;

namespace Sprout.Exam.UnitTests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private string _connectionstring = "Server=localhost\\SQLEXPRESS02;Database=SproutExamDb;Trusted_Connection=True;";

        [TestMethod]
        public void GetEmployees_HasEmployeesReturned()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_connectionstring);
            AppDbContext appDbContext = new AppDbContext(optionsBuilder.Options);

            var employeeService = new EmployeeService(appDbContext);

            //Act
            //NOTE: METHOD CONNECTS TO ACTUAL DATABASE. CAN MOCK DB CALL IN THE FUTURE
            var employees = employeeService.GetEmployees();

            //Assert
            Assert.IsTrue(employees.Count > 0, "No employees returned");
        }

        [TestMethod]
        public void CalculateEmployeePay_ContractualEmployee()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_connectionstring);
            AppDbContext appDbContext = new AppDbContext(optionsBuilder.Options);

            var employeeService = new EmployeeService(appDbContext);

            //Act
            //NOTE: METHOD CONNECTS TO ACTUAL DATABASE. CAN MOCK DB CALL IN THE FUTURE
            var finalMonthlyPay = employeeService.CalculateEmployeePay(1, 0, 15.5m);

            //Assert
            Assert.AreEqual("7750.00", finalMonthlyPay.ToString("0.00"), "Incorrect Pay Calculation");
        }

        [TestMethod]
        public void CalculateEmployeePay_RegularEmployee()
        {
            //Arrange
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_connectionstring);
            AppDbContext appDbContext = new AppDbContext(optionsBuilder.Options);

            var employeeService = new EmployeeService(appDbContext);

            //Act
            //NOTE: METHOD CONNECTS TO ACTUAL DATABASE. CAN MOCK DB CALL IN THE FUTURE
            var finalMonthlyPay = employeeService.CalculateEmployeePay(2, 1, 0);

            //Assert
            Assert.AreEqual("16690.91", finalMonthlyPay.ToString("0.00"), "Incorrect Pay Calculation");
        }
    }
}
