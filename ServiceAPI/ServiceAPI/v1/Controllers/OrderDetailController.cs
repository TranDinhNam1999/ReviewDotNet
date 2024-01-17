using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Common.Types;
using ServiceAPI.v1.Commands;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;
using ServiceAPI.v1.RequestModel;

namespace ServiceAPI.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedResult<OrderDetailDto>> GetOrderDetailListAsync()
        {
            var data = await mediator.Send(new GetOrderDetailListQuery());

            return data;
        }
    }
}
