using MediatR;

namespace EasyFinance.Application.BankAccountTransaction.ShowBankAccountTransactions;

public record ShowBankAccountTransactionHistoryCommand(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;