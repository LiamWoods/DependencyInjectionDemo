using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DependencyInjectionDemo.Utils.FactoryItems
{
    public class ExternalCakeFactory : ICakeFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ExternalCakeFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Cake> Bake(CakeStyle style)
        {
            if (style == CakeStyle.ChocolateFudge)
            {
                return await FrozenFudgeCake();
            }

            var freshClient = _httpClientFactory.CreateClient("fresh");
            return await GetCakeCore(style.ToString(), freshClient);
        }

        private async Task<Cake> FrozenFudgeCake()
        {
            var staleClient = _httpClientFactory.CreateClient("stale");
            return await GetCakeCore(CakeStyle.ChocolateFudge.ToString(), staleClient);
        }

        private async Task<Cake> GetCakeCore(string cakeType, HttpClient client)
        {
            var response = await client.GetAsync(cakeType);
            var cakeStr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Cake>(cakeStr);
        }
    }
}
