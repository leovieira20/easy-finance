namespace EasyFinance.Web.Models.Output
{
    public partial record MonthlyBreakdownDtoPublicModel
    {
        public int Month { get; set; }
        public decimal Balance { get; set; }
    }
}