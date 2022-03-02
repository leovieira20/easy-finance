using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.GetBankAccountOverview;

public record GetBankAccountOverviewCommand(BankAccountId bankAccountId,
    DateTime startDate,
    DateTime endDate) : IRequest<BankAccountOverviewDto>;