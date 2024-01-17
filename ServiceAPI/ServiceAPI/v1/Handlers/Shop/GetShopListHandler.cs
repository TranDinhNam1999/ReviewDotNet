using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.Customer
{
    public class GetShopListHandler : IRequestHandler<GetShopListQuery, PagedResult<ShopDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetShopListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<ShopDto>> Handle(GetShopListQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.ShopRepository.GetShopListAsync();

            return PagedResult<ShopDto>.Create(items.OrderByDescending(s => s.Location),
               currentPage: 1,
               resultsPerPage: items.Count(),
               totalPages: 1,
               totalResults: items.Count());
        }

    }
}
