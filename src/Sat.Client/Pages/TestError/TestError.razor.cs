using Microsoft.AspNetCore.Components;
using Sat.Client.Infrastructure.Interceptors;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sat.Client.Pages.TestError
{
    public partial class TestError : IDisposable
    {
        [Inject] public HttpClient _httpClient { get; set; }
        [Inject] public HttpInterceptorService Interceptor { get; set; }

        protected override void OnInitialized()
        {
            Interceptor.RegisterEvent();
        }

        private Task Get500Error()
        {
            var response = _httpClient.GetAsync("buggy/servererror");
            Console.WriteLine(response);

            return response;
        }

        private Task Get400Error()
        {
            var response = _httpClient.GetAsync("buggy/badrequest");
            Console.WriteLine(response);

            return response;
        }

        private Task Get404Error()
        {
            var response = _httpClient.GetAsync("products/42");
            Console.WriteLine(response);

            return response;
        }

        private Task Get400ValidationError()
        {
            var response = _httpClient.GetAsync("products/fortytwo");
            return response;
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}
