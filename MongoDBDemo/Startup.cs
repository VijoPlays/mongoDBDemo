using Microsoft.OpenApi.Models;
using MongoDBDemo.Components;
using MongoDBDemo.MongoDB;
using MongoDBDemo.Repository;
using MongoDBDemo.Services;

namespace MongoDBDemo;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mongo DB Demo", Version = "v1" });
        });

        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
        services.AddSingleton<MongoDbContext>();
        services.AddSingleton<IStudentService, StudentService>();
        services.AddSingleton<IStudentRepository, StudentRepository>();

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAntiforgery();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
        });
    }
}