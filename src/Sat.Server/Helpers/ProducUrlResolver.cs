using AutoMapper;
using Microsoft.Extensions.Configuration;
using Sat.Core.DTOs;
using Sat.Core.Entities;

namespace Sat.Server.Helpers
{
    public class ProducUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProducUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(
            Product source, 
            ProductToReturnDto destination, 
            string destMember, 
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _configuration["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}
