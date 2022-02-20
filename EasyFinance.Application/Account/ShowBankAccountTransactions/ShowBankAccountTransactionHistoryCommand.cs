using MediatR;

namespace EasyFinance.Application.Account.ShowBankAccountTransactions;

public record ShowBankAccountTransactionHistoryCommand(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;