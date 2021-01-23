﻿using Microsoft.AspNetCore.Components;

namespace Sat.Client.Components
{
    public partial class SearchComponent
    {
        private string SearchTerm { get; set; }
        
        [Parameter] public EventCallback<string> OnSearchChanged { get; set; }

        private void OnClick()
        {
            OnSearchChanged.InvokeAsync(SearchTerm);
        }
    }
}
