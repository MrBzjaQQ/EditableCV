using EditableCV_backend.Data.Migrator;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace EditableCV_backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            await MigrateDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // TODO: DependencyInjection.cs + extension method
        private static async Task<IHost> MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var identityDbMigrator = scope.ServiceProvider.GetRequiredService<IResumeDbMigrator>();
            await identityDbMigrator.MigrateAsync();
            await identityDbMigrator.SeedDataAsync();
            return host;
        }
    }
}
