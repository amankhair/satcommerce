using Sat.Core.RequestFeatures;
using System.Collections.Generic;

namespace Sat.Client.Features
{
    public class PagingResponse<T> where T : class
    {
        public IReadOnlyList<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }
}
