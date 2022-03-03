using MediatR;

namespace EasyFinance.Application.BankAccountTransactionCommands.ShowBankAccountTransactions;

public record ShowBankAccountTransactionHistoryCommand(Guid BankAccountId) : IRequest<List<BankAccountTransactionDto>>;