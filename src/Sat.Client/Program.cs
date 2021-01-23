using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sat.Client.Infrastructure.Interceptors;
using Sat.Client.Infrastructure.Services.Products;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Sat.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("SatCommerceAPI", (sp, cl) =>
            {
                cl.BaseAddress = new Uri("https://localhost:5011/api/");
                cl.EnableIntercept(sp);
            });
            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("SatCommerceAPI"));

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddHttpClientInterceptor();
            builder.Services.AddScoped<HttpInterceptorService>();

            await builder.Build().RunAsync();
        }
    }
}
