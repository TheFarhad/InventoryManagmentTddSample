namespace IM.Application.Inventory;

using Contract;
using Domain.Inventory;

public class InventoryApplication : IInventoryApplication
{
    private readonly IInventoryRepository _repository;

    public InventoryApplication(IInventoryRepository repository) =>
        _repository = repository;

    public static InventoryApplication New(IInventoryRepository repository) =>
        new InventoryApplication(repository);

    public long Create(InventoryCreateCommand command)
    {
        var model = Inventory.New(command.Product, command.Price);
        var result = _repository.Add(model);
        //_repository.Save();
        return result;
    }
}
