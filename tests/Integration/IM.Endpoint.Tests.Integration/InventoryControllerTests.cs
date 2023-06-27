namespace IM.Endpoint.Tests.Integration;

using FluentAssertions;
using ClassFixtures;
using Application.Contract;

public class InventoryControllerTests : IClassFixture<InventoryControllerClassFixture>, IDisposable
{
    private readonly InventoryControllerClassFixture _fixture;

    public InventoryControllerTests(InventoryControllerClassFixture fixture) =>
         _fixture = fixture;

    [Fact]
    public async void Should_Be_Return_True_When_Add_Inventory()
    {
        // Arrange(setup fixture)


        // Act(exercise)
        var response = await _fixture
            .RestfulClient
            .PostContentAsync<InventoryCreateCommand, long>(_fixture.Path, _fixture.Command);

        // Assert(verify)
        response.Should().Be(5);
    }

    public void Dispose() { }
}


