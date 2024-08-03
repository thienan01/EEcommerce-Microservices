using BuildingBlocks.CQRS;
using System.Windows.Input;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResponse>;
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResponse>
    {
        public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            //TODO: Delete basket
            return new DeleteBasketResponse(true);
        }
    }
}
