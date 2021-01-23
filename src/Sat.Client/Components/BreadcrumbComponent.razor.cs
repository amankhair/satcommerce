using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Client.Components
{
    public partial class BreadcrumbComponent
    {
        [Parameter] public List<BreadCrumbData> BreadCrumbDatas { get; set; }
    }

    public class BreadCrumbData
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }
}
