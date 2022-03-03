namespace EasyFinance.Domain.Accounts;

public class CreditCard
{
    private CreditCard(string name)
    {
        Id = CreditCardId.New();
        Name = name;
    }
    
    public static CreditCard Create(string name)
    {
        return new CreditCard(name);
    }
    
    public void SetDefaultPaymentAmount(int amount)
    {
        Settings.DefaultPaymentAmount = amount;
    }
    
    public void RegisterTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
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
    public CreditCardSettings Settings { get; set; } = new CreditCardSettings();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}