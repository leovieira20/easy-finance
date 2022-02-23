using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Application.Account.RegisterDepositToBankAccount;
using EasyFinance.Application.Account.ShowBankAccountTransactions;
using EasyFinance.Application.AccountOverview.GetBankAccountOverview;
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
            .ForType<MonthlyBreakdownDto>();

        config.GenerateMapper("[name]Mapper")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>()
            .ForType<BankAccountOverviewDto>()
            .ForType<MonthlyBreakdownDto>();
    }
}