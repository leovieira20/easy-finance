using MediatR;

namespace EasyFinance.Application.Overview;

public record GetCreditCardOverviewCommand(Guid CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<CreditCardOverviewDto>;