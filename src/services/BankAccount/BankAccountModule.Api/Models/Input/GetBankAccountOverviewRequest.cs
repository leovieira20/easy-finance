namespace BankAccountModule.Api.Models.Input;

public class GetBankAccountOverviewRequest
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}