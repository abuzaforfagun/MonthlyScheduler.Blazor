using MonthlyBillScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Domain.Services
{
    public class BillService : IBillService
    {
        private readonly List<BillItem> _bills;

        public BillService()
        {
            _bills = new List<BillItem>
            {
                new BillItem {Id = 1, Name = "Internet Bill", Description = "Send internet bill to Link3", Amount = 1200, CreatedOn = new DateTime(2020, 04, 12)},
                new BillItem {Id = 2, Name = "Gas Bill", Description = "Send gas bill to Titash", Amount = 1500, CreatedOn = new DateTime(2020, 04, 11)},
                new BillItem {Id = 3, Name = "Servant Fee", Description = "Send servant fee though bKash", Amount = 3000, CreatedOn = new DateTime(2020, 04, 12)},
            };
        }

        public void Add(BillItem bill)
        {
            _bills.Add(bill);
        }

        public Task<List<BillItem>> GetAll()
        {
            return Task.FromResult(_bills);
        }
    }
}
