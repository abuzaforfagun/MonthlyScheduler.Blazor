using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;

namespace MonthlyBillScheduler.Server.Pages.BillForm
{
    public class BillFormBase : ComponentBase
    {
        [Inject]
        public IBillService BillService { get; set; }
        [Parameter]
        public string BillId { get; set; }
        public BillItem Bill { get; set; }

        protected override void OnInitialized()
        {
            Bill = string.IsNullOrWhiteSpace(BillId) ? new BillItem() : BillService.Get(int.Parse(BillId));

            base.OnInitialized();
        }
        public void SaveBillEntry()
        {
            BillService.Upsert(Bill);
            Bill = new BillItem();
        }
    }
}
