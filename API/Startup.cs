using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data; 
using DataAccess.AccesoDatos; 
using DataAccess.Interfaces; 

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configurar EF Core con SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddCors();
        // Registrar el repositorio de especies
        services.AddScoped<IEspecie, EspecieAD>();
        services.AddScoped<IFamilia, FamiliaAD>();
        services.AddScoped<IUbicacion, UbicacionAD>();
        services.AddScoped<ISemilla, SemillaAD>();

        // Configurar controladores y JSON
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(options =>
        {
            options.WithOrigins("https://localhost:7099", "http://localhost:7099")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
