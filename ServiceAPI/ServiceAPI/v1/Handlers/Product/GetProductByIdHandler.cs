using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, PagedResult<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<ProductDto>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.ProductRepository.GetProductByIdAsync(Guid.Parse(query.Id));

            List<ProductDto> result = new List<ProductDto>();
            result.Add(items);

            return PagedResult<ProductDto>.Create(result,
                   currentPage: 1,
                   resultsPerPage: 1,
                   totalPages: 1,
                   totalResults: 1);
        }
    }
}
