using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview;

public record GetBankAccountOverviewCommand(BankAccountId bankAccountId,
    DateTime startDate,
    DateTime endDate) : IRequest<List<MonthlyBreakdownDto>>;