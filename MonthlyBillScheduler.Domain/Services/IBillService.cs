using MonthlyBillScheduler.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Domain.Services
{
    public interface IBillService
    {
        Task<List<BillItem>> GetAll();
        BillItem Get(int id);
        void Upsert(BillItem bill);
        void Delete(int id);
    }
}
