using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Queries
{
    public class GetShopByIdQuery : IRequest<PagedResult<ShopDto>>
    {
        public string Id { get; set; }
    }
}
