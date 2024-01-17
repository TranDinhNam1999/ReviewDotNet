using MediatR;
using ServiceAPI.v1.Models;

namespace ServiceAPI.v1.Commands
{
    public class CreateShopCommand : IRequest<ShopDto>
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public CreateShopCommand(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
