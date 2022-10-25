using balasolu.contexts;
using balasolu.services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace balasolu.extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> MigrateDefaultDbContextAsync(this WebApplication application)
        {
            using var scope = application.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DefaultDbContext>();
            await context.Database.MigrateAsync();
            return application;
        }

        public static async Task<WebApplication> MigrateKeyDbContextAsync(this WebApplication application)
        {
            using var scope = application.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<KeyDbContext>();
            await context.Database.MigrateAsync();
            return application;
        }

        public static async Task<WebApplication> MigrateCryptoDbContextAsync(this WebApplication application)
        {
            using var scope = application.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<CryptoDbContext>();
            await context.Database.MigrateAsync();
            return application;
        }

        public static async Task InitializeAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var atomService = serviceProvider.GetRequiredService<IAtomService>();
            //await atomService.UpdateDefaultFeedsAsync();
            //_ = Task.Run(async () => await atomService.UpdateTwitterFeedsAsync());
        }
    }
}
