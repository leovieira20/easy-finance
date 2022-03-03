using EasyFinance.Application.GetBankAccountOverview;
using EasyFinance.Application.Register;
using EasyFinance.Application.RegisterBankAccount;
using EasyFinance.Application.RegisterDepositToBankAccount;
using EasyFinance.Application.ShowBankAccountTransactions;
using EasyFinance.Domain;
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
            .ForType<BankAccountOverviewDto>()
            .ForType<MonthlyBreakdownDto>()
            .ForType<CreditCardDto>()
            .ForType<CreditCardSettings>();

        config.GenerateMapper("[name]Mapper")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>()
            .ForType<BankAccountOverviewDto>()
            .ForType<MonthlyBreakdownDto>()
            .ForType<CreditCardDto>()
            .ForType<CreditCardSettings>();
    }
}