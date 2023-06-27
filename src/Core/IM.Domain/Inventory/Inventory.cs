namespace IM.Domain.Inventory;

using System;
using Exceptions;

public class Inventory
{
    public long Id { get; private set; }
    public string Product { get; private set; }
    public double Price { get; private set; }
    public bool InStock { get; private set; }

    protected Inventory() { }
    protected Inventory(string product, double price)
    {
        ProductValidate(product);
        PriceValidate(price);

        Product = product;
        Price = price;
        InStock = false;
    }

    public static Inventory New(string product, double price) =>
        new(product, price);

    private void ProductValidate(string product)
    {
        if (String.IsNullOrWhiteSpace(product))
            throw new InvalidProductException("");
    }

    private void PriceValidate(double price)
    {
        if (price <= 0)
            throw new InvalidPriceException("");
    }
}
