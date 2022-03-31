using EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;
using EasyFinance.Application.BankAccountCommands.RegisterBankAccount;
using EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;
using EasyFinance.Application.BankAccountTransactionCommands.ShowBankAccountTransactions;
using EasyFinance.Application.CreditCardCommands.Register;
using EasyFinance.Domain.Accounts;
using Mapster;

namespace EasyFinance.Web.Infrastructure;

public class MapsterConfigurations : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]PublicModel")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>()
            .ForType<MonthlyBreakdownDto>()
            .ForType<CreditCardDto>()
            .ForType<CreditCardSettings>();

        config.GenerateMapper("[name]Mapper")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>()
            .ForType<MonthlyBreakdownDto>()
            .ForType<CreditCardDto>()
            .ForType<CreditCardSettings>();
    }
}