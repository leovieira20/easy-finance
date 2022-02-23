using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.AccountOverview.GetBankAccountOverview;

public record GetBankAccountOverviewCommand(BankAccountId bankAccountId,
    DateTime startDate,
    DateTime endDate) : IRequest<BankAccountOverviewDto>;