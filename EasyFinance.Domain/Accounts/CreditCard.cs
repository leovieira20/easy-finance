namespace EasyFinance.Domain.Accounts;

public class CreditCard
{
    private CreditCard(string name)
    {
        Name = name;
    }
    
    public static CreditCard Create(string name)
    {
        return new CreditCard(name);
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}