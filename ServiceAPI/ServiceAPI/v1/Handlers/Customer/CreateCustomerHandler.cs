using MediatR;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Commands;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Handlers.Customer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CustomerDto> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new CustomerDto()
            {
                FullName = command.FullName,
                DateOfBirth = command.DateOfBirth,
                Email = command.Email,
                Id = new Guid(),
            };

            var data = _unitOfWork.CustomerRepository.AddCustomerAsync(customer);
            await _unitOfWork.CommitAsync();

            return data.Result;
        }
    }
}
