using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart ShoppingCart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket{userName}", async (StoreBasketRequest shoppingCart, ISender sender) =>
            {
                var result = await sender.Send(new StoreBasketCommand(shoppingCart.ShoppingCart));

                var response = result.Adapt<StoreBasketResponse>();

                return Results.Ok(response);
            })
                .WithName("CreateBasket")
                .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("CreateBasket")
                .WithDescription("CreateBasket");
        }
    }
}
