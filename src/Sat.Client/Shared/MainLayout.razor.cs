using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Sat.Client.Infrastructure.Interceptors;
using System;
using System.Collections.Generic;

namespace Sat.Client.Shared
{
    public partial class MainLayout
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        private void SearchChanged(string searchTerm)
        {
            Console.WriteLine($"from main: {searchTerm}");
            var queryParams = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                NavigationManager.NavigateTo("shop/c/categories");
            }
            else
            {
                queryParams.Add("text", searchTerm);
                NavigationManager.NavigateTo(QueryHelpers.AddQueryString("shop/c/categories", queryParams));
            }
        }

    }
}