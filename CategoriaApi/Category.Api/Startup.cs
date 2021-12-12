
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Categories.Api.Configuration;
using Categories.Infra.Data.MySql.Contexts;
using Categories.Api.Configuration;

namespace Categories.Api.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddFluentValidation()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

            #region Auto Mapper
            services.AddAutoMapper();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação", Version = "v1" });
            });

            services.RegisterServices();         
            
            services.AddDbContext<CategoryContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MySql"), ServerVersion.AutoDetect(Configuration.GetConnectionString("MySql")));
            });

            AppSettingsConfig config = new AppSettingsConfig();
            Configuration.GetSection("Settings").Bind(config);

            services.AddSingleton<AppSettingsConfig>(config);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AllowCors(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();
        }

        private void AllowCors(IApplicationBuilder app)
        {
            app.UseCors(c =>
                        c.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
        }

    }
}
