using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceAPI.Common;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAPI_Test.RepositoriesTest
{
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly Mock<LibraryDbContext> _dBcontext;

        public CustomerRepositoryTest()
        {
            _dBcontext = new Mock<LibraryDbContext>();
            _customerRepository = new CustomerRepository(_dBcontext.Object);
        }

        private static List<CustomerDto> GetFakeEmployeeList()
        {
            return new List<CustomerDto>()
            {
                new CustomerDto
                {
                    DateOfBirth = DateTime.Now,
                    FullName = "Nam",
                    Email =
                    "nam@nam",
                    IsDeleted = false,
                    Id = Guid.NewGuid()
                },
                new CustomerDto
                {
                    DateOfBirth = DateTime.Now,
                    FullName = "BBB",
                    Email =
                    "BB@BB",
                    IsDeleted = false,
                    Id = Guid.NewGuid()
                }
            };
        }

        [Fact]
        public async Task CreateCustomer_ShouldbeReturnValue()
        {
            var employeeContextMock = new Mock<LibraryDbContext>();
            employeeContextMock.Setup(x => x.Customer.FindAsync(1).Result)
                .Returns(GetFakeEmployeeList().Find(e => e.IsDeleted == false) ?? new CustomerDto());
            // Arrange
            //_dBcontext.Setup(x => x.SaveChanges());
            //var customer = new CustomerDto { 
            //    DateOfBirth = DateTime.Now, 
            //    FullName = "Nam", 
            //    Email = 
            //    "nam@nam", 
            //    IsDeleted = false,
            //    Id = Guid.NewGuid()
            //};
            // Act
            var result =  _customerRepository.GetCustomerListAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Nam", result?.Result?.FirstOrDefault()?.FullName);
        }
    }
}
