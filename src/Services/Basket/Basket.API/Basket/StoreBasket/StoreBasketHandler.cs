using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketHandler(IBasketRepository basketRepository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            //TODO: store basket
            await basketRepository.StoreBasket(request.ShoppingCart, cancellationToken);
            return new StoreBasketResult(request.ShoppingCart.UserName);
        }
    }
}
