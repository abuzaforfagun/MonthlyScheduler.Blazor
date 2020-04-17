using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Server.Components.Dialogs;
using MonthlyBillScheduler.Server.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Server.Pages.Bills
{
    public class BillsBase : ComponentBase
    {
        [Inject]
        public IBillDataService BillService { get; set; }

        public List<BillItem> Bills { get; set; }

        public BillFormDialogBase BillFormDialog { get; set; }
        public bool IsShowDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Bills = await BillService.GetAllAsync();
        }

        public async void DeleteBill(int id)
        {
            await BillService.DeleteAsync(id);
            var item = Bills.Single(b => b.Id == id);
            Bills.Remove(item);
            StateHasChanged();
        }

        public void DisplayAddBillDialog() => IsShowDialog = true;
        public void BillFormDialog_OnClose() => IsShowDialog = false;


        public async void BillFormDialog_OnSave()
        {
            Bills = await BillService.GetAllAsync();
            IsShowDialog = false;
            StateHasChanged();
        }
    }
}
