using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wiz.TesteWiz.Domain.Interfaces.Services;

namespace Wiz.TesteWiz.Infra.Services
{
    public class BlipService : IBlipService
    {
        private readonly HttpClient _httpClient;

        public BlipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> SendMessageAsync(object resource)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(resource),Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("messages", stringContent);

            return await result.Content.ReadAsStringAsync();
        }
    }
}
