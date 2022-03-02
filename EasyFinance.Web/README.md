# Mapster
## run mapster codegen
`dotnet msbuild -t:Mapster`

## run mapster clean
`dotnet msbuild -t:CleanGenerated`

# Backlog
## features
- Set credit card limit
- Set credit card threshold
- Set credit card payment forecast till zeroes
- Add "real balance" when credit card debt exists
- Implement authentication

## tech debt
- migrate `Web.Tests.Integration` to Specflow
- implement request validation on `BankAccountOverviewController.Get`

## known issues
- `MonthlyBreakdownDto` will probably have to change `Month` from `int` to `DateTime`

## high level
- implement tye with Dapr
- implement Dapr
- implement backstage
