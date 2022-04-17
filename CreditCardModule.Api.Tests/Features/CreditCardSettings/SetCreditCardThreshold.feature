Feature: SetCreditCardThreshold	

Scenario: Set credit card threshold
	Given a registered credit card	
	When I set the threshold to 100 euros
	Then threshold on my card is 100 euros