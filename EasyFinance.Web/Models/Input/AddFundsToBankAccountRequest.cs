namespace EasyFinance.Web.Models.Input;

public class AddFundsToBankAccountRequest
{
    public Guid BankAccountId { get; set; }
    public decimal Amount { get; set; }
}