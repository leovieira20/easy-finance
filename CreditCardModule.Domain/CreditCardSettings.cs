namespace CreditCardModule.Domain;

public class CreditCardSettings
{
    internal CreditCardSettings()
    {
        Id = CreditCardSettingsId.New();
    }
    
    public CreditCardSettingsId Id { get; set; }
    public decimal Limit { get; set; }
    public decimal Threshold { get; set; }
    public decimal DefaultPaymentAmount { get; set; }
    
    public CreditCardId CreditCardId { get; set; }
}