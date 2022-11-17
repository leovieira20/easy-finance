using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Application.Models;
using MediatR;

namespace BankAccounts.Application;

public static class RegisterPaymentToBankAccount
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
                .Bind(x => x.RegisterDebit(request.date, request.Amount, string.Empty))
                .Bind(x => _repository.Update(x))
                .MapAsync(x => _repository.SaveChangesAsync(x))
                .Match(
                    Some: account => new() { Balance = account.Balance },
                    None: () => new BankAccountSummaryDto());
        }
    }    
}