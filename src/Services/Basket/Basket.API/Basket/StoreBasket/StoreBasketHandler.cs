using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.CQRS;
using Discount.GRPC.Protos;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.ShoppingCart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
                if (coupon != null)
                {
                    item.Price -= decimal.Parse(coupon.Amount);
                }

            }
            //TODO: store basket
            await basketRepository.StoreBasket(request.ShoppingCart, cancellationToken);
            return new StoreBasketResult(request.ShoppingCart.UserName);
        }
    }
}
