Feature: AddFundsToBankAccount	

Scenario: Add funds to existing account
	Given existing bank account with no balance	
	When I add 1 to the bank account
	Then the new balance should be 1