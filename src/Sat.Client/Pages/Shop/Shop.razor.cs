using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Sat.Client.Extensions;
using Sat.Client.Infrastructure.Interceptors;
using Sat.Client.Infrastructure.Services.Products;
using Sat.Core.DTOs;
using Sat.Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Client.Pages.Shop
{
    public partial class Shop : IDisposable
    {
        [Inject] public HttpInterceptorService Interceptor { get; set; }


        protected override void OnInitialized()
        {
            Interceptor.RegisterEvent();
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}
