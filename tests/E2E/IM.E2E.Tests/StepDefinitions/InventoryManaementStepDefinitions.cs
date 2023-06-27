namespace IM.E2E.Tests.StepDefinitions;

using RestSharp;
using Newtonsoft.Json;
using Application.Contract;
using HostApplication;

[Binding]
public class InventoryManaementStepDefinitions
{
    private InventoryCreateCommand _command;
    private RestClient _restClient;
    private long _result;

    [Given(@"I Want To Add The Following Inventory")]
    public void GivenIWantToAddTheFollowingInventory(Table table) =>
         _command = table.CreateInstance<InventoryCreateCommand>();

    [When(@"I Try To Define The Inventory")]
    public void WhenITryToDefineTheInventory()
    {
        _restClient = new RestClient(InventoryHostOptions.BaseUrl);
        var request = new RestRequest("/api/inventory");
        request.AddJsonBody(_command);
        var response = _restClient.Post(request);
        _result = JsonConvert.DeserializeObject<long>(response.Content);
    }

    [Then(@"It Should Be Created")]
    public void ThenItShouldBeCreated()
    {
        _result.Should().Be(7);
    }
}
