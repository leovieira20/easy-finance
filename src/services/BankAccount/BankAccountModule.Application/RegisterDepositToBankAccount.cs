using BankAccountModule.Application.Models;
using BankAccountModule.Domain;
using MediatR;

namespace BankAccountModule.Application;

public static class RegisterDepositToBankAccount
{
    public record Command(Guid BankAccountId, decimal Amount, DateTime date) : IRequest<BankAccountSummaryDto>;
    class Handler : IRequestHandler<Command, BankAccountSummaryDto>
    {
        private readonly IBankAccountRepository _repository;

        public Handler(IBankAccountRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<BankAccountSummaryDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var bankAccount = await _repository.GetAsync(new BankAccountId(request.BankAccountId));
        
            return await bankAccount
                .Some(x => RegisterCreditAsync(x, request))
                .None(Task.FromResult(new BankAccountSummaryDto()));
        }

        private async Task<BankAccountSummaryDto> RegisterCreditAsync(BankAccount bankAccount, Command request)
        {
            bankAccount.RegisterCredit(request.date, request.Amount, string.Empty);

            await _repository.Update(bankAccount);

            return new BankAccountSummaryDto
            {
                Balance = bankAccount.Balance
            };
        }
    }    
}