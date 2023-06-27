namespace IM.Application.Contract;

public interface IInventoryApplication
{
    long Create(InventoryCreateCommand command);
}
