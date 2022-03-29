namespace EasyFinance.Application.AccountOverviewCommands.GetBankAccountOverview
{
    public partial record MonthlyBreakdownDtoPublicModel
    {
        public int Month { get; set; }
        public decimal Balance { get; set; }
    }
}