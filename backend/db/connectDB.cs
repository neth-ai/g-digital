// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    // ...

    services.AddDbContext<ApplicationDbContext>();

    services.AddControllers();

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ...

    app.UseCors("AllowAll");

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
