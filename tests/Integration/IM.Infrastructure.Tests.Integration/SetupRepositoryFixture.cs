namespace IM.Infrastructure.Tests.Integration;

using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Context;
using Domain.Inventory;
using Repositories;

public class SetupRepositoryFixture : IDisposable
{
    private readonly IMContext _context;
    public readonly IInventoryRepository Repository;
    private readonly TransactionScope _scope;

    public SetupRepositoryFixture()
    {
        var dbContextOptions = new DbContextOptionsBuilder<IMContext>()
          .UseSqlServer("Server=.\\Develop; Database=Inventory; User Id=sa; Password=masih; Persist Security Info=True; Trust Server Certificate=true")
          .Options;
        _context = new IMContext(dbContextOptions);
        Repository = new InventoryRepository(_context);
        _scope = new TransactionScope();
    }

    public void Dispose()
    {
        _scope.Dispose();
        _context.Dispose();
    }
}
