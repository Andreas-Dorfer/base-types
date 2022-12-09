using TestApp.Infrastructure;

namespace TestApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
