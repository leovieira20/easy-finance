using MediatR;

namespace EasyFinance.Application.ShowBankAccountTransactions;

public record ShowBankAccountTransactionHistoryCommand(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;