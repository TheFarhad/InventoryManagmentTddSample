namespace IM.Infrastructure.Tests.Integration;

using FluentAssertions;
using Domain.Inventory;

public class InventoryRepositoryTests : IDisposable, IClassFixture<SetupRepositoryFixture>
{
    private readonly SetupRepositoryFixture _fixture;

    public InventoryRepositoryTests(SetupRepositoryFixture fixture) =>
         _fixture = fixture;

    [Fact]
    public void Should_Return_Id_When_Add_Inventory()
    {
        // Arrange(setup fixture)
        var command = Inventory.New("Asus", 10);

        // Act(exercise)
        var id = _fixture.Repository.Add(command);

        // Assert(verify)
        id.Should().NotBe(0);
    }

    [Fact]
    public void Should_Get_Inventory_With_Specified_Name()
    {
        // Arrange
        var command = Inventory.New("Apple Watch", 3260);
        _fixture.Repository.Add(command);

        // Act
        var defiendInventory = _fixture.Repository.Get(command.Product);

        // Assert 
        defiendInventory.Id.Should().NotBe(0);
        defiendInventory.Should().NotBeNull();
    }

    [Fact]
    public void Should_Return_List_Of_Inventories()
    {
        // Arrange(setup fixture)


        // Act(exercise)
        var inventories = _fixture.Repository.GetAll();

        // Assert(verify)
        inventories.Should().HaveCount(0);
    }

    [Fact]
    public void Should_Delete_Specified_Inventory()
    {
        // Arrange(setup fixture)
        var command = Inventory.New("Bike", 2500);
        var id = _fixture.Repository.Add(command);

        // Act(exercise)
        _fixture.Repository.Delete(id);

        // Assert(verify)
        _fixture.Repository.Get(id).Should().BeNull();
    }

    public void Dispose() { }
}
