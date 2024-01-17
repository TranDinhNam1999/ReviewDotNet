using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Common.Types;
using ServiceAPI.v1.Commands;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;
using ServiceAPI.v1.ResponeModel;

namespace ServiceAPI.v1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedResult<CustomerDto>> GetCustomerListAsync()
        {
            var customerDto = await mediator.Send(new GetCustomerListQuery());

            return customerDto;
        }

        [HttpGet("CustomerId")]
        public async Task<PagedResult<CustomerDto>> GetStudentByIdAsync(string customerId)
        {
            var customerDto = await mediator.Send(new GetCustomerByIdQuery() { Id = customerId });

            return customerDto;
        }

        [HttpPost]
        public async Task<CustomerDto> AddCustomerAsync(CustomerReq CustomerRes)
        {
            var studentDetail = await mediator.Send(new CreateCustomerCommand(
                CustomerRes.FullName,
                CustomerRes.DateOfBirth,
                CustomerRes.Email));
            return studentDetail;
        }
    }
}
