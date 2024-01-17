using MediatR;
using ServiceAPI.Common.Types;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Models;
using ServiceAPI.v1.Queries;

namespace ServiceAPI.v1.Handlers.Customer
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, PagedResult<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<CustomerDto>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.CustomerRepository.GetCustomerByIdAsync(Guid.Parse(query.Id));

            List<CustomerDto> result = new List<CustomerDto>();
            result.Add(items);

            return PagedResult<CustomerDto>.Create(result,
                   currentPage: 1,
                   resultsPerPage: 1,
                   totalPages: 1,
                   totalResults: 1);
        }
    }
}
