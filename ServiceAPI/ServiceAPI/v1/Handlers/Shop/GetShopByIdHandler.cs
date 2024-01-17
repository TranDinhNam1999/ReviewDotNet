using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.Customer
{
    public class GetShopByIdHandler : IRequestHandler<GetShopByIdQuery, PagedResult<ShopDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetShopByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<ShopDto>> Handle(GetShopByIdQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.ShopRepository.GetShopByIdAsync(Guid.Parse(query.Id));

            List<ShopDto> result = new List<ShopDto>();
            result.Add(items);

            return PagedResult<ShopDto>.Create(result,
                   currentPage: 1,
                   resultsPerPage: 1,
                   totalPages: 1,
                   totalResults: 1);
        }
    }
}
