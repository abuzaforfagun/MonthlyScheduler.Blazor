using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;

namespace MonthlyBillScheduler.Server.Components.BillFormCore
{
    public class BillFormCoreBase : ComponentBase
    {
        [Inject]
        public IBillService BillService { get; set; }
        [Parameter]
        public BillItem Bill { get; set; } = new BillItem();

        [Parameter]
        public EventCallback<bool> SaveEventCallBack { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        public async void SaveBillEntry()
        {
            BillService.Upsert(Bill);
            Bill = new BillItem();
            await SaveEventCallBack.InvokeAsync(true);
        }
    }
}
