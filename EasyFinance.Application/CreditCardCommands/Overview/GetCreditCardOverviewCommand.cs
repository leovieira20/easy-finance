using EasyFinance.Domain.Accounts;
using MediatR;

namespace EasyFinance.Application.CreditCardCommands.Overview;

public record GetCreditCardOverviewCommand(CreditCardId CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<CreditCardMonthlyBreakdownDto>>;