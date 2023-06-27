namespace IM.Endpoint.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Contract;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryApplication _inventoryApplication;

    public InventoryController(IInventoryApplication inventoryApplication) =>
        _inventoryApplication = inventoryApplication;

    [HttpPost]
    public long Create(InventoryCreateCommand command) =>
        _inventoryApplication.Create(command);
}
