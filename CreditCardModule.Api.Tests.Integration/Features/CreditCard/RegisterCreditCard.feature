Feature: RegisterCreditCard

Scenario: Register new credit card
    Given I haven't registered any credit cards yet
    When I register a valid credit card
    Then credit card is created