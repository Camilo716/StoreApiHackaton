using System.Text.Json.Serialization;
using HackatonApi.Data.EntityFramework;
using HackatonApi.Data.Repositories;
using HackatonApi.Services;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup));

        services.AddControllers()
                .AddJsonOptions(
                    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseSqlServer(_config.GetConnectionString("defaultConnection"))
            );

        services.AddScoped<IProductRepository, EfProductRepository>();
        services.AddScoped<ProductService>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void ConfigureMiddlewares(IApplicationBuilder app, IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}