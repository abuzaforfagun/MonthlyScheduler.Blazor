using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;
using MonthlyBillScheduler.Server.Components.BillFormCore;
using MonthlyBillScheduler.Server.Components.Dialogs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Server.Pages.Bills
{
    public class BillsBase : ComponentBase
    {
        [Inject]
        public IBillService BillService { get; set; }

        public List<BillItem> Bills { get; set; }

        public BillFormDialogBase BillFormDialog { get; set; }
        public bool ShowDialog { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Bills = await BillService.GetAll();
        }

        public void DeleteBill(int id)
        {
            BillService.Delete(id);
        }

        public void DisplayAddBillDialog() => ShowDialog = true;
        public void BillFormDialog_OnClose() => ShowDialog = false;


        public async void BillFormDialog_OnSave()
        {
            Bills = await BillService.GetAll();
            ShowDialog = false;
            StateHasChanged();
        }
    }
}
