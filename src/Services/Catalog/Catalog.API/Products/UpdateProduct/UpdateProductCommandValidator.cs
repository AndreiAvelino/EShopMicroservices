namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotEmpty()
         .NotNull()
         .WithMessage("Id was not provided");

        RuleFor(x => x.Name)
           .NotEmpty()
           .NotNull()
           .WithMessage("Name is required")
           .Length(2, 150)
           .WithMessage("Name must have between 2 and 150 caracters");

        RuleFor(x => x.ImageFile)
            .NotEmpty()
            .NotNull()
            .WithMessage("ImageFile is required");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required");

        RuleFor(x => x.Price)
            .NotNull()
            .WithMessage("Price is required")
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}