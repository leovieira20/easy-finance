# Docker
# SqlServer
`docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD={password}" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge`

# Mapster

## run mapster codegen

`dotnet msbuild -t:Mapster`

## run mapster clean

`dotnet msbuild -t:CleanGenerated`

# EF

## run EF migrations

### add
within EasyFinance.Web project

`dotnet ef migrations add Initial -p ../EasyFinance.Db.SqlServer -o ./EF/Migrations`

# Backlog

## features

- Show credit card overview
- Implement outstanding credit card balance
- Register credit card transaction
- Register credit card payment
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
