Feature: RegisterPayment
    
    @ignore
    Scenario: Bank account with 0 balance gets negative when making payment of 1 euro
        Given existing bank account with default name
        When I make a payment of 1 euro
        Then my balance is -1