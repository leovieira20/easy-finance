using System;

namespace EasyFinance.Web.Models.Output
{
    public partial record MonthlyBreakdownDtoPublicModel
    {
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Balance { get; set; }
    }
}