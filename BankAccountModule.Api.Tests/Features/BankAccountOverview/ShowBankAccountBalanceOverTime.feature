Feature: ShowBankAccountBalanceOverTime

    Scenario: Show balance for three months
        Given my bank account has some transactions
          | Month | Amount |
          | 0     | 10     |
          | 1     | 20     |
          | 2     | 30     |
        When I request the account overview for 3 months
        Then I see a monthly overview
          | Month | Balance |
          | 0     | 10      |
          | 1     | 30      |
          | 2     | 60      |