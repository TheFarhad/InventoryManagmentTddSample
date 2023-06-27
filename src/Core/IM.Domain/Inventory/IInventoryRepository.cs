namespace IM.Domain.Inventory;

public interface IInventoryRepository
{
    long Add(Inventory source);
    List<Inventory> GetAll();
    Inventory? Get(string product);
    Inventory? Get(long id);
    void Delete(long id);
    void Save();
}
