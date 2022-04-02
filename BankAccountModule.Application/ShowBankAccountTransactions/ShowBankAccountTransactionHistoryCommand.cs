using MediatR;

namespace BankAccountModule.Application.ShowBankAccountTransactions;

public record ShowBankAccountTransactionHistoryCommand(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;