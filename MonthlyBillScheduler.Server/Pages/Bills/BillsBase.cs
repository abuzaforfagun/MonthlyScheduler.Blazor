using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;
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
        public bool IsShowDialog { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Bills = await BillService.GetAll();
        }

        public void DeleteBill(int id)
        {
            BillService.Delete(id);
        }

        public void DisplayAddBillDialog() => IsShowDialog = true;
        public void BillFormDialog_OnClose() => IsShowDialog = false;


        public async void BillFormDialog_OnSave()
        {
            Bills = await BillService.GetAll();
            IsShowDialog = false;
        }
    }
}
