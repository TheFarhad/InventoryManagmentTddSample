namespace IM.Domain.Tests.Unit.Builder;

using Inventory;

public class InventoryTestBuilder
{
    public long Id { get; private set; }
    public string Product { get; private set; } = "Mac";
    public double Price { get; private set; } = 100;
    public bool InStock { get; private set; } = false;

    public Inventory Build() =>
        Inventory.New(Product, Price);

    public InventoryTestBuilder WithProduct(string product)
    {
        Product = product;
        return this;
    }

    public InventoryTestBuilder WithPrice(double price)
    {
        Price = price;
        return this;
    }

    public InventoryTestBuilder WithInStock()
    {
        InStock = true;
        return this;
    }
}
