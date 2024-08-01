﻿
namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is greater than 0");
        }
    }

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Bussiness logic to create a product
            var product = new Product
            {
                Name = request.Name,
                Category = request.Category,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price,
            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
