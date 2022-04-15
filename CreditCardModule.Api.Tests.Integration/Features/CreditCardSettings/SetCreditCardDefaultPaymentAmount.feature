Feature: SetCreditCardDefaultPaymentAmount	

Scenario: Set credit card default payment amount
	Given a registered credit card	
	When I set the default payment amount to 100 euros
	Then default payment amount on my card is 100 euros