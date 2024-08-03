using Basket.API.Data;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketHandler(IBasketRepository basketRepository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            //TODO: Delete basket
            await basketRepository.DeleteBasket(request.UserName, cancellationToken);
            return new DeleteBasketResult(true);
        }
    }
}
