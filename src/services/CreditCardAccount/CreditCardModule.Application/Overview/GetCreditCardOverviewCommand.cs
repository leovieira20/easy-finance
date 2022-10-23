using CreditCardModule.Domain;
using MediatR;

namespace CreditCardModule.Application.Overview;

public record GetCreditCardOverviewCommand(CreditCardId CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<CreditCardMonthlyBreakdownDto>>;