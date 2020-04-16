using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;
using Sotsera.Blazor.Toaster;

namespace MonthlyBillScheduler.Server.Pages.BillForm
{
    public class BillFormBase : ComponentBase
    {
        [Inject]
        public IBillService BillService { get; set; }
        [Inject]
        protected IToaster Toaster { get; set; }
        [Parameter]
        public string BillId { get; set; }
        public BillItem Bill { get; set; }

        bool isEditMode;

        protected override void OnInitialized()
        {
            Bill = string.IsNullOrWhiteSpace(BillId) ? new BillItem() : BillService.Get(int.Parse(BillId));
            isEditMode = Bill.Id > 0;
            base.OnInitialized();
        }
        public void SaveBillEntry()
        {
            BillService.Upsert(Bill);
            if (isEditMode)
            {
                Toaster.Info("Bill updated sucessfully!");
            }
            else
            {
                Bill = new BillItem();
                Toaster.Info("Bill added sucessfully");
            }
        }
    }
}
