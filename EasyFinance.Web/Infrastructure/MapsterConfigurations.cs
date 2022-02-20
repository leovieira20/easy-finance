using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Application.Account.RegisterDepositToBankAccount;
using EasyFinance.Application.Account.ShowBankAccountTransactions;
using Mapster;

namespace EasyFinance.Web.Infrastructure;

public class MapsterConfigurations : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]PublicModel")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>();

        config.GenerateMapper("[name]Mapper")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>();
    }
}