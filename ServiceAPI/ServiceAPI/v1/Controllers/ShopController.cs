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
    public class ShopController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShopController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedResult<ShopDto>> GetShopListAsync()
        {
            var customerDto = await mediator.Send(new GetShopListQuery());

            return customerDto;
        }

        [HttpGet("ShopId")]
        public async Task<PagedResult<ShopDto>> GetShopByIdAsync(string shopId)
        {
            var customerDto = await mediator.Send(new GetShopByIdQuery() { Id = shopId });

            return customerDto;
        }

        [HttpPost]
        public async Task<ShopDto> AddShopAsync(ShopReq req)
        {
            var studentDetail = await mediator.Send(new CreateShopCommand(
                req.Name,
                req.Location));
            return studentDetail;
        }
    }
}
