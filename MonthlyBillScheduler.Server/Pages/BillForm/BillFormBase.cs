using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Entities.Models;
using MonthlyBillScheduler.Server.Components.BillFormCore;
using MonthlyBillScheduler.Server.Services;
using Sotsera.Blazor.Toaster;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Server.Pages.BillForm
{
    public class BillFormBase : ComponentBase
    {
        [Inject]
        public IBillDataService BillService { get; set; }
        [Inject]
        protected IToaster Toaster { get; set; }
        [Parameter]
        public string BillId { get; set; }
        public BillItem Bill { get; set; }
        public BillFormCoreBase BillFormCore { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Bill = string.IsNullOrWhiteSpace(BillId) ? new BillItem() : await BillService.GetAsync(int.Parse(BillId));
        }

        public async void BillFormCore_OnSave()
        {
            await BillService.SaveAsync(Bill);
            Toaster.Info("Bill updated sucessfully!");
        }
    }
}
