using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Server.Components.BillFormCore;

namespace MonthlyBillScheduler.Server.Components.Dialogs
{
    public class BillFormDialogBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public EventCallback<bool> SaveEventCallBack { get; set; }

        public BillFormCoreBase BillFormCore { get; set; }

        public async void CloseDialog()
        {
            await CloseEventCallback.InvokeAsync(true);
        }

        public async void BillFormCore_OnSave()
        {
            await SaveEventCallBack.InvokeAsync(true);
        }
    }
}
