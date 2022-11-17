using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Application.Models;
using MediatR;

namespace BankAccounts.Application;

public static class RegisterDepositToBankAccount
{
    public record Command(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;
    internal class Handler : IRequestHandler<Command, BankAccountSummaryDto>
    {
        private readonly IBankAccountRepository _repository;

        public Handler(IBankAccountRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<BankAccountSummaryDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var bankAccount = await _repository.GetAsync(new(request.BankAccountId));
        
            return await bankAccount
                .Map(x => x.RegisterCredit(request.date, request.Amount, string.Empty))
                .MapAsync(x => _repository.UpdateAsync(x))
                .Some(x => new BankAccountSummaryDto { Balance = x.Balance })
                .None(new BankAccountSummaryDto());
        }
    }    
}