@bankAccount
Feature: RegisterDepositToBankAccount

    Rule: Non-Existent account

        Scenario: Trying to register a deposit to non-existent account
            Given inexistent bank account
            When I register a deposit of 1 to the bank account
            Then deposit is not registered

    Rule: Existing account

        Scenario: Register deposit to existing account
            Given existing bank account with no balance
            When I register a deposit of 1 to the bank account
            Then the new balance should be 1