namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IDocumentSession _session = session;

    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = _session.LoadAsync<Product>(command.Id);

        if(product is null)
        {
            throw new ProductNotFoundException(command.Id);
        }
        
        _session.Delete<Product>(command.Id);

        await _session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}