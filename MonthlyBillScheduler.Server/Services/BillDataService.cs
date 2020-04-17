using MonthlyBillScheduler.Entities.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonthlyBillScheduler.Server.Services
{
    public class BillDataService : IBillDataService
    {
        private readonly HttpClient httpClient;

        public BillDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task DeleteAsync(int id)
        {
            await httpClient.DeleteAsync($"bills/{id}");
        }

        public async Task<List<BillItem>> GetAllAsync()
        {
            var result = (await httpClient.GetStringAsync("bills"));
            return JsonSerializer.Deserialize<List<BillItem>>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<BillItem> GetAsync(int id)
        {
            var result = await httpClient.GetStringAsync($"bills/{id}");
            return JsonSerializer.Deserialize<BillItem>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveAsync(BillItem bill)
        {
            var billJson = new StringContent(JsonSerializer.Serialize(bill), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("bills", billJson); 
        }
    }
}
