using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.Account.RegisterBankAccount;

public class RegisterBankAccountCommand : IRequest<BankAccount>
{
    public RegisterBankAccountCommand(string bankAccountName)
    {
        BankAccountName = bankAccountName;
    }
    
    public string BankAccountName { get; }
}