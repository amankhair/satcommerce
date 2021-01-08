namespace Sat.Core.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
    }
}
