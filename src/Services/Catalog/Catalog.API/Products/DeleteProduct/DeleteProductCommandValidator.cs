namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotEmpty()
         .NotNull()
         .WithMessage("Id was not provided");
    }
}