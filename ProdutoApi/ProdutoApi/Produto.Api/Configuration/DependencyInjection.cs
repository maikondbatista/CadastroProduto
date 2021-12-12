using FluentValidation;
using Products.Domain.Entites;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;
using Products.Domain.Validations;
using Products.Infra.Data.MySql.Contexts;
using Products.Service.Services;

namespace Products.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ProductContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();

            services.AddTransient<IValidator<Product>, ProductValidator>();

            services.AddTransient<HttpClient, HttpClient>();
        }
    }
}
