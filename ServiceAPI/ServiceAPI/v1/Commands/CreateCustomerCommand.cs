using MediatR;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public CreateCustomerCommand(string fullName, DateTime dateOfBirth, string email)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }
}
