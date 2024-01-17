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
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedResult<ProductDto>> GetProductListAsync()
        {
            var data = await mediator.Send(new GetProductListQuery());

            return data;
        }

        [HttpGet("ShopId")]
        public async Task<PagedResult<ProductDto>> GetProductByIdAsync(string shopId)
        {
            var data = await mediator.Send(new GetProductByIdQuery() { Id = shopId });

            return data;
        }

        [HttpPost]
        public async Task<ProductDto> AddProductAsync(ProductReq req)
        {
            var data = await mediator.Send(new CreateProductCommand(
                req.Name,
                req.Price));
            return data;
        }
    }
}
