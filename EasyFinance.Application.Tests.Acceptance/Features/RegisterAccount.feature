Feature: RegisterAccount

    Scenario: Register Account
        Given I want to keep track of my finances
        When I register an account
        Then the account should be available