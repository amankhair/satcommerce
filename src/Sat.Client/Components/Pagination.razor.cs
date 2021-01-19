﻿using Microsoft.AspNetCore.Components;
using Sat.Client.Features;
using Sat.Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Client.Components
{
    public partial class Pagination
    {
        #region Parameters

        [Parameter] public MetaData MetaData { get; set; }
        [Parameter] public int Spread { get; set; }
        [Parameter] public EventCallback<int> SelectedPage { get; set; }

        #endregion

        #region Fields

        private List<PagingLink> _links;

        #endregion

        #region Methods

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();
            _links.Add(new PagingLink(MetaData.CurrentPage - 1, MetaData.HasPrevious, "Previous"));
            for (int i = 1; i <= MetaData.TotalPages; i++)
            {
                if (i >= MetaData.CurrentPage - Spread && i <= MetaData.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = MetaData.CurrentPage == i });
                }
            }
            _links.Add(new PagingLink(MetaData.CurrentPage + 1, MetaData.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == MetaData.CurrentPage || !link.Enabled)
                return;

            MetaData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }

        #endregion
    }
}