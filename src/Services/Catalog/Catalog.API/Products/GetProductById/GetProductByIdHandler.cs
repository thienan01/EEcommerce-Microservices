using Catalog.API.Exceptions;
using Marten.Linq.SoftDeletes;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GetProductByIdHandler.Handle called with:",request);
            
            var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
            
            if (product == null)
                throw new ProductNotFoundException();

            return new GetProductByIdResult(product);
        }
    }
}
