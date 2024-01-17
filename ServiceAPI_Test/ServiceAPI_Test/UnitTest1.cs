using Moq;
using ServiceAPI.Common;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Commands;
using ServiceAPI.v1.Handlers.Customer;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI_Test
{
    public class UnitTest1 : IDisposable
    {
        public void Dispose () { }

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
        public async Task Handle_ShouldCreateCustomerAndCommitAsync()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.CustomerRepository.GetCustomerListAsync().Result)
                .Returns(GetFakeEmployeeList());

            var handler = new GetCustomerListHandler(unitOfWorkMock.Object);
            var query = new GetCustomerListQuery();

            var expected = GetFakeEmployeeList();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("BBB", result?.Items?.FirstOrDefault()?.FullName);
        }
    }
}