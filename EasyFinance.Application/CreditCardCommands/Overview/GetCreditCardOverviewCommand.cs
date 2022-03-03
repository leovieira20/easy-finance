using MediatR;

namespace EasyFinance.Application.CreditCardCommands.Overview;

public record GetCreditCardOverviewCommand(Guid CreditCardId, DateTime StartDate, DateTime EndDate) : IRequest<CreditCardOverviewDto>;