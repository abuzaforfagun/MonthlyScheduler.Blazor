using Microsoft.AspNetCore.Components;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Server.Pages.Bills
{
    public class BillsBase : ComponentBase
    {
        [Inject]
        public IBillService BillService { get; set; }

        public List<BillItem> Bills { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Bills = await BillService.GetAll();
        }
    }
}
