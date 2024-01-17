using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.Customer
{

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, PagedResult<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<CustomerDto>> Handle(GetCustomerListQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.CustomerRepository.GetCustomerListAsync();

            return PagedResult<CustomerDto>.Create(items.OrderBy(c => c.Email),
               currentPage: 1,
               resultsPerPage: items.Count(),
               totalPages: 1,
               totalResults: items.Count());
        }

    }
}
