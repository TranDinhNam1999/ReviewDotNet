using MediatR;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Commands;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Handlers.Customer
{
    public class CreateShopHandler : IRequestHandler<CreateShopCommand, ShopDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateShopHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<ShopDto> Handle(CreateShopCommand command, CancellationToken cancellationToken)
        {
            var data = new ShopDto()
            {
                Name = command.Name,
                Location = command.Location,
                Id = new Guid(),
            };

            _ = _unitOfWork.ShopRepository.AddShopAsync(data);
            await _unitOfWork.CommitAsync();

            return data;
        }
    }
}
