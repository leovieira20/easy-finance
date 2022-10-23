using BankAccountModule.Domain;
using MediatR;

namespace BankAccountModule.Application.GetBankAccountOverview;

public record GetBankAccountOverviewCommand(BankAccountId bankAccountId,
    DateTime startDate,
    DateTime endDate) : IRequest<List<MonthlyBreakdownDto>>;