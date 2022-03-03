namespace EasyFinance.Domain.Accounts;

public class CreditCardSettings
{
    internal CreditCardSettings()
    {
        Id = CreditCardSettingsId.New();
    }
    
    public CreditCardSettingsId Id { get; set; }
    public decimal Limit { get; set; }
    public decimal Threshold { get; set; }
    
    public CreditCardId CreditCardId { get; set; }
}