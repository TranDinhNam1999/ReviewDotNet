using MediatR;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Commands;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var data = new ProductDto()
            {
                Name = command.Name,
                Price = command.Price,
                Id = new Guid(),
            };

            _ = _unitOfWork.ProductRepository.AddProductAsync(data);
            await _unitOfWork.CommitAsync();

            return data;
        }
    }
}
