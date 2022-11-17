namespace CreditCards.Domain;

public class CreditCard
{
    private CreditCard(string name)
    {
        Id = CreditCardId.New();
        Name = name;
    }
    
    private CreditCard(CreditCardId id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public static CreditCard Create(string name)
    {
        return new(name);
    }
    
    public static CreditCard Create(CreditCardId id, string name)
    {
        return new(id, name);
    }
    
    public void SetDefaultPaymentAmount(int amount)
    {
        Settings.DefaultPaymentAmount = amount;
    }

    public void SetLimit(decimal limitAmount)
    {
        Settings.Limit = limitAmount;
    }
    
    public void SetThreshold(decimal amount)
    {
        Settings.Threshold = amount;
    }
    
    public void SetDefaultPaymentAmount(decimal amount)
    {
        Settings.DefaultPaymentAmount = amount;
    }

    public CreditCardId Id { get; set; }
    public string Name { get; set; }
    public CreditCardSettings Settings { get; set; } = new();
    public ICollection<CreditCardTransaction> Transactions { get; set; } = new List<CreditCardTransaction>();
}