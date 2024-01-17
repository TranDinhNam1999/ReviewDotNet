using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.Product
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, PagedResult<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<ProductDto>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.ProductRepository.GetProductListAsync();

            return PagedResult<ProductDto>.Create(items.OrderBy(c => c.Name),
               currentPage: 1,
               resultsPerPage: items.Count(),
               totalPages: 1,
               totalResults: items.Count());
        }

    }
}
