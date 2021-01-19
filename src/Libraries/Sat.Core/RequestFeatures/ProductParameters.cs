namespace Sat.Core.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public long? BrandId { get; set; }
        public long? TypeId { get; set; }
        public string Sort { get; set; }
    }
}
