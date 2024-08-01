using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductQuery() : IQuery<GetProductResult>;
    public record GetProductResult(IEnumerable<Product> Products);
    internal class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
        : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductQueryHandler.Handle called with {@query}", request);
            var products = await session.Query<Product>().ToListAsync();
            return new GetProductResult(products);
        }
    }
}
