@InventoryManaement
Feature: Inventory Manaement

	As A Warehouse Keeper
	I Want To Keep Track Of My Inventory
	So That I Always Have Accurate Info  About Product Stock

#@SenarioTag
Scenario: Definie New Inventory
	Given I Want To Add The Following Inventory
		| Product | Price |
		| Mac     | 1000  |
	When I Try To Define The Inventory
	Then It Should Be Created

