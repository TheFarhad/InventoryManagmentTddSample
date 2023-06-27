namespace IM.Endpoint.Tests.Integration.ClassFixtures;

using System.Transactions;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using Application.Contract;

public class InventoryControllerClassFixture : IDisposable
{
    public readonly string Path = "/api/inventory";
    public readonly RESTFulApiFactoryClient RestfulClient;
    public readonly InventoryCreateCommand Command;
    //private readonly TransactionScope _scope;

    public InventoryControllerClassFixture()
    {
        var factory = new WebApplicationFactory<Program>();
        var httpClient = factory.CreateClient();
        RestfulClient = new RESTFulApiFactoryClient(httpClient);
        Command = new InventoryCreateCommand
        {
            Price = 100,
            Product = "IPhone"
        };
        //var transactionOptions = new TransactionOptions();
        //transactionOptions.IsolationLevel = IsolationLevel.Snapshot;
        //transactionOptions.Timeout = TransactionManager.MaximumTimeout;
        //_scope = new TransactionScope(/*TransactionScopeOption.RequiresNew, transactionOptions, */TransactionScopeAsyncFlowOption.Enabled);
    }

    public void Dispose()
    {
        // _scope.Dispose();
    }
}
