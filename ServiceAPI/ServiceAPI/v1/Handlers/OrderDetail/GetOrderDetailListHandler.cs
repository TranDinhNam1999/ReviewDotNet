using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.OrderDetail
{
    public class GetOrderDetailListHandler : IRequestHandler<GetOrderDetailListQuery, PagedResult<OrderDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderDetailListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<OrderDetailDto>> Handle(GetOrderDetailListQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.OrderDetailRepository.GetOrderDetailListAsync();
            items = items.OrderBy(c => c.productName);
            items = items.OrderByDescending(s => s.shopLocation);
            items = items.OrderBy(c => c.customerEmail);

            return PagedResult<OrderDetailDto>.Create(items,
                   currentPage: 1,
                   resultsPerPage: 1,
                   totalPages: 1,
                   totalResults: 1);
        }

    }
}
