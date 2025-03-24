using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using PayrollApi.Controllers;
using PayrollApi.Data;
using PayrollApi.Models;
using Xunit;
using System.Threading.Tasks;

namespace PayrollApi.Tests.Controllers
{
    public class PayrollControllerTest
    {

        readonly DbContextOracle _context = new DbContextOracle();

        [Fact]
        public void GetAll_ShouldReturnAllPayrolls()
        {
            //Arrange
            
            var controller = new PayrollController(_context)
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
            var controller = new PayrollController(_context)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var newPayroll = new Payroll
            {
                EmployeeName = "John Doe",
                Salary = 3000.00m,
                PaymentDate = DateTime.UtcNow
            };

            // Act
            var result = controller.Add(newPayroll);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_ShouldReturnASpecificPayroll()
        {
            //Arrange
            
            var controller = new PayrollController(_context)
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
            
            await controller.Add(newPayroll);
            
            var result = controller.Get(id);
            
            //Assert
            
            Assert.NotNull(result);
            
        }
        
        [Fact]
        public async Task Delete_ShouldDeleteASpecificPayroll()
        {
            //Arrange

            const int id = 1;
            
            var controller = new PayrollController(_context)
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
            
            //Act
            
            await controller.Add(newPayroll);
            
            var result = controller.Delete(id);
            
            //Assert
            
            Assert.NotNull(result);
            
        }
        
        [Fact]
        public async Task Put_ShouldUpdateASpecificPayroll()
        {
            //Arrange
            
            var controller = new PayrollController(_context)
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
            
            await controller.Add(newPayroll);
            
            var result = await controller.Put(id, newPayrollUpdate) as OkNegotiatedContentResult<Payroll>;
            
            //Assert
            
            Assert.Equal(newPayrollUpdate.Id, result?.Content.Id);
            
        }
        
    }
}