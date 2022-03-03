# Mapster

## run mapster codegen

`dotnet msbuild -t:Mapster`

## run mapster clean

`dotnet msbuild -t:CleanGenerated`

# Backlog

## features

- Set credit card threshold
- Set credit card default payment amount
- Show credit card overview forecast till zeroes (forecast on)
- Show credit card overview
- Add "real balance" when credit card debt exists
- Implement authentication

## tech debt

- migrate `Web.Tests.Integration` to Specflow
- implement request validation on `BankAccountOverviewController.Get`
- reduce visibility of modules

## known issues

- `MonthlyBreakdownDto` will probably have to change `Month` from `int` to `DateTime`

## high level

- implement tye with Dapr
- implement Dapr
- implement backstage
