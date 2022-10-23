@bankAccount
Feature: ShowBankAccountTransactionHistory

    Rule: Inexistent account       
        Scenario: Inexistent account
            Given inexistent bank account
            When bank account transactions are listed
            Then no transactions are shown

    Rule: Existent account

        Scenario: Show bank account transactions
            Given existing bank account with one deposit
              | Amount |
              | 1      |
            When bank account transactions are listed
            Then one deposit is shown
              | Amount |
              | 1      |