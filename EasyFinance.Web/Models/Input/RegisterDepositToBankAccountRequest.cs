namespace EasyFinance.Web.Models.Input;

public class RegisterDepositToBankAccountRequest
{
    public Guid BankAccountId { get; set; }
    public decimal Amount { get; set; }
}