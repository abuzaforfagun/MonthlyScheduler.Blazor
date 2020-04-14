using System;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillScheduler.Domain.Models
{
    public class BillItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
