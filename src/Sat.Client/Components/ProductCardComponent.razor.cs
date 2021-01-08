using Microsoft.AspNetCore.Components;
using Sat.Core.DTOs;

namespace Sat.Client.Components
{
    public partial class ProductCardComponent
    {
        [Parameter] public ProductToReturnDto Product { get; set; }
    }
}
