using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;
using System;

namespace MonthlyBillScheduler.Server.Pages.BillForm
{
    public class BillFormBase : ComponentBase
    {
        [Inject]
        public IBillService BillService { get; set; }
        public BillItem Bill { get; set; } = new BillItem { CreatedOn = DateTime.Now };

        public void AddBillEntry()
        {
            BillService.Add(Bill);
            Bill = new BillItem { CreatedOn = DateTime.Now }; ;
        }
    }
}
