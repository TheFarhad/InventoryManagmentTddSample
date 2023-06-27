namespace IM.Infrastructure.Repositories;

using Context;
using Domain.Inventory;

public class InventoryRepository : IInventoryRepository
{
    private readonly IMContext _context;

    public InventoryRepository(IMContext context) =>
        _context = context;

    public long Add(Inventory source)
    {
        _context.Inventories.Add(source);
        Save();
        return source.Id;
    }

    public Inventory? Get(string product) =>
         _context.Inventories.FirstOrDefault(_ => _.Product == product);

    public Inventory? Get(long id) =>
         _context.Inventories.Find(id);

    public List<Inventory> GetAll() =>
         _context.Inventories.ToList();

    public void Delete(long id)
    {
        var model = Get(id);
        _context.Inventories.Remove(model);
        Save();
    }

    public void Save() =>
    _context.SaveChanges();
}
