using MonthlyBillScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Domain.Services
{
    public class BillService : IBillService
    {
        private readonly List<BillItem> _bills;
        private readonly Random _random;

        public BillService()
        {
            _random = new Random();
            _bills = new List<BillItem>
            {
                new BillItem {Id = 1, Name = "Internet Bill", Description = "Send internet bill to Link3", Amount = 1200, CreatedOn = new DateTime(2020, 04, 12)},
                new BillItem {Id = 2, Name = "Gas Bill", Description = "Send gas bill to Titash", Amount = 1500, CreatedOn = new DateTime(2020, 04, 11)},
                new BillItem {Id = 3, Name = "Servant Fee", Description = "Send servant fee though bKash", Amount = 3000, CreatedOn = new DateTime(2020, 04, 12)},
            };
        }

        public void Upsert(BillItem bill)
        {
            if(bill.Id == 0)
            {
                bill.Id = _random.Next();
                bill.CreatedOn = DateTime.Now;
                _bills.Add(bill);
            }
            else
            {
                var existingBill = _bills.SingleOrDefault(b => b.Id == bill.Id);
                existingBill.Name = bill.Name;
                existingBill.Amount = bill.Amount;
                existingBill.Description = bill.Description;
                existingBill.ModifiedOn = DateTime.Now;
            }
        }

        public BillItem Get(int id)
        {
            return _bills.SingleOrDefault(b => b.Id == id);
        }

        public Task<List<BillItem>> GetAll()
        {
            return Task.FromResult(_bills);
        }

        public void Delete(int id)
        {
            var bill = _bills.SingleOrDefault(b => b.Id == id);
            _ = bill ?? throw new Exception();
            _bills.Remove(bill);
        }
    }
}
