﻿namespace EasyFinance.Web.Models.Input;

public class CreditCardOverviewRequest
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}