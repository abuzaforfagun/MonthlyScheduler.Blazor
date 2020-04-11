using MonthlyBillScheduler.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Domain.Services
{
    public interface IBillService
    {
        Task<List<BillItem>> GetAll();
    }
}
