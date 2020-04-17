using MonthlyBillScheduler.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Server.Services
{
    public interface IBillDataService
    {
        Task<List<BillItem>> GetAllAsync();
        Task<BillItem> GetAsync(int id);
        Task SaveAsync(BillItem bill);
        Task DeleteAsync(int id);
    }
}
