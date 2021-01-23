using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sat.Client.Pages.TestError
{
    public partial class TestError
    {
        [Inject] public HttpClient _httpClient { get; set; }

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

        private void Get400ValidationError()
        {
            try
            {
                var response = _httpClient.GetAsync("products/fortytwo");
                Console.WriteLine(response);
            }
            catch (Exception e)
            {
                string validerror = e.Message;
                Console.WriteLine(validerror);
            }
        }
    }
}
