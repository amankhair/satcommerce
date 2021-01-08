using Sat.Core.RequestFeatures;
using System;
using System.Collections.Generic;

namespace Sat.Server.Paging
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public IReadOnlyList<T> Items { get; set; }

        public PagedList(int pageNumber, int pageSize, int count, IReadOnlyList<T> items)
        {
            MetaData = new MetaData
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            Items = items;
        }
    }
}
