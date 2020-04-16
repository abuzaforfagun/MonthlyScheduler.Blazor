using Microsoft.AspNetCore.Mvc;
using MonthlyBillScheduler.Domain.Models;
using MonthlyBillScheduler.Domain.Services;

namespace MonthlyBillScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService billService;

        public BillsController(IBillService billService)
        {
            this.billService = billService;
        }

        [HttpGet]
        public ActionResult GetAll() => Ok(billService.GetAll());

        [HttpGet("{id}")]
        public ActionResult Get(int id) => Ok(billService.Get(id));

        [HttpPost]
        public ActionResult Upsert(BillItem bill)
        {
            billService.Upsert(bill);
            return Created($"/{bill.Id}", bill);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            billService.Delete(id);
            return Ok();
        }
    }
}
