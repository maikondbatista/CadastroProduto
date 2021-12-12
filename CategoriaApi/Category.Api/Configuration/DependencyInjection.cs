using FluentValidation;
using Categories.Domain.Entites;
using Categories.Domain.Interfaces.Repositories;
using Categories.Domain.Interfaces.Services;
using Categories.Domain.Validations;
using Categories.Infra.Data.MySql.Contexts;
using Categories.Service.Services;

namespace Categories.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CategoryContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddTransient<IValidator<Category>, CategoryValidator>();

            services.AddTransient<HttpClient, HttpClient>();
        }
    }
}
