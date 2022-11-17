using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Application.Models;
using MediatR;

namespace BankAccounts.Application;

public static class RegisterBankAccount
{
    public record Command(string BankAccountName) : IRequest<BankAccountDto>;
    internal class Handler : IRequestHandler<Command, BankAccountDto>
    {
        private readonly IBankAccountRepository _repository;

        public Handler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<BankAccountDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var bankAccount = BankAccount.Create(request.BankAccountName);

            await _repository.CreateAsync(bankAccount);
        
            return new()
            {
                Id = bankAccount.Id.Value,
                Name = bankAccount.Name,
                Status = bankAccount.Status
            };
        }
    }    
}