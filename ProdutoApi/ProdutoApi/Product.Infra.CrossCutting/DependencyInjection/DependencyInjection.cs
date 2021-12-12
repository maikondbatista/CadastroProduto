using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;
using Products.Infra.Data.MySql.Contexts;
using Products.Service.Services;

namespace Products.Infra.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ProductContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
        }
    }
}
