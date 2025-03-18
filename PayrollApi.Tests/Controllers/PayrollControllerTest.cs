using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using PayrollApi.Controllers;
using PayrollApi.Models;
using Xunit;

namespace PayrollApi.Tests.Controllers
{
    public class PayrollControllerTest
    {
        [Fact]
        public void GetAll_ShouldReturnAllPayrolls()
        {
            //Arrange
            
            var controller = new PayrollController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            
            //Act
            
            var result = controller.GetAll();
            
            //Assert
            
            Assert.NotNull(result);
            
        }
        
        [Fact]
        public void Add_ShouldAddPayrollAndReturnIt()
        {
            // Arrange
            var controller = new PayrollController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var newPayroll = new Payroll
            {
                EmployeeName = "John Doe",
                Salary = 3000.00m,
                PaymentDate = DateTime.Now
            };

            // Act
            var result = controller.Add(newPayroll);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ShouldReturnASpecificPayroll()
        {
            //Arrange
            
            var controller = new PayrollController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var newPayroll = new Payroll
            {
                EmployeeName = "John Doe",
                Salary = 3000.00m,
                PaymentDate = DateTime.Now
            };

            var id = 1;
            
            //Act
            
            controller.Add(newPayroll);
            
            var result = controller.Get(id);
            
            //Assert
            
            Assert.NotNull(result);
            
        }
        
        [Fact]
        public void Delete_ShouldDeleteASpecificPayroll()
        {
            //Arrange
            
            var controller = new PayrollController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var newPayroll = new Payroll
            {
                EmployeeName = "John Doe",
                Salary = 3000.00m,
                PaymentDate = DateTime.Now
            };

            var id = 1;
            
            //Act
            
            controller.Add(newPayroll);
            
            var result = controller.Delete(id);
            
            //Assert
            
            Assert.NotNull(result);
            
        }
        
        [Fact]
        public void Put_ShouldUpdateASpecificPayroll()
        {
            //Arrange
            
            var controller = new PayrollController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var newPayroll = new Payroll
            {
                EmployeeName = "John Doe",
                Salary = 3000.00m,
                PaymentDate = DateTime.Now
            };
            
            var newPayrollUpdate = new Payroll
            {
                EmployeeName = "John Doe",
                Salary = 4000.00m,
                PaymentDate = DateTime.Now
            };

            var id = 1;
            
            //Act
            
            controller.Add(newPayroll);
            
            var result = controller.Put(id, newPayrollUpdate) as OkNegotiatedContentResult<Payroll>;
            
            //Assert
            
            Assert.Equal(newPayrollUpdate.Id, result?.Content.Id);
            
        }
        
    }
}