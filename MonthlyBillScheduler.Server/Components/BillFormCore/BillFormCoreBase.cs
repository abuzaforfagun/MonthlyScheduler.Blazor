using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Server.Services;

namespace MonthlyBillScheduler.Server.Components.BillFormCore
{
    public class BillFormCoreBase : ComponentBase
    {
        [Inject]
        public IBillDataService BillService { get; set; }
        [Parameter]
        public BillItem Bill { get; set; } = new BillItem();

        [Parameter]
        public EventCallback<bool> SaveEventCallBack { get; set; }

        public async void SaveBillEntry()
        {
            await BillService.SaveAsync(Bill);
            Bill = new BillItem();
            await SaveEventCallBack.InvokeAsync(true);
        }
    }
}
