using MediatR;

namespace EasyFinance.Application.Account.AddFundsToBankAccount;

public record AddFundsToBankAccountCommand : IRequest<BankAccountSummaryDTO>
{
    public AddFundsToBankAccountCommand(Guid bankAccountId, decimal amount)
    {
        BankAccountId = bankAccountId;
        Amount = amount;
    }

    public Guid BankAccountId { get; }
    public decimal Amount { get; }
}