Feature: GetCreditCardOverview

    Scenario: Debt of 100 euros is paid overtime by default payment amount
        Given a registered credit card
        And the credit card has a default payment amount of 30 euros
        And a credit card has transactions
          | Date       | Amount | Description |
          | 2022-03-01 | 100    | Test        |
        When credit card overview is set for 2022-03-01 and 2022-06-01
        Then credit card overview per month shows
          | Date       | ForecastBalance |
          | 2022-03-01 | 70              |
          | 2022-04-01 | 40              |
          | 2022-05-01 | 10              |
          | 2022-06-01 | 0               |