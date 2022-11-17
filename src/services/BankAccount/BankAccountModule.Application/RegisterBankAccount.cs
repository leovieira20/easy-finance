using BankAccountModule.Application.Models;
using BankAccountModule.Domain;
using MediatR;

namespace BankAccountModule.Application;

public static class RegisterBankAccount
{
    public record Command(string BankAccountName) : IRequest<BankAccountDto>;
    class Handler : IRequestHandler<Command, BankAccountDto>
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
        
            return new BankAccountDto
            {
                Id = bankAccount.Id.Value,
                Name = bankAccount.Name,
                Status = bankAccount.Status
            };
        }
    }    
}