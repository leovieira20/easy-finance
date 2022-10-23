using MediatR;

namespace BankAccountModule.Application.GetBankAccountTransactions;

public record GetBankAccountTransactionsCommand(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;