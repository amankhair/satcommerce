using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sat.Client.HttpRepository;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sat.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5011/api/") });
            builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();

            await builder.Build().RunAsync();
        }
    }
}
