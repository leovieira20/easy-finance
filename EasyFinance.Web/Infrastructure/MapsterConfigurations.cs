using BankAccountModule.Application.RegisterBankAccount;
using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Application.ShowBankAccountTransactions;
using CreditCardModule.Application.Register;
using CreditCardModule.Domain;
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
            .ForType<CreditCardDto>()
            .ForType<CreditCardSettings>();

        config.GenerateMapper("[name]Mapper")
            .ForType<BankAccountDto>()
            .ForType<BankAccountSummaryDto>()
            .ForType<BankAccountTransactionDto>()
            .ForType<CreditCardDto>()
            .ForType<CreditCardSettings>();
    }
}