Feature: SetCreditCardLimit

    @ignore
    Scenario: Set credit card limit
        Given a registered credit card
        When I set the limit to 100 euros
        Then limit on my card is 100 euros