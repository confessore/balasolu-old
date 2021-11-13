using balasolu.web.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace balasolu.web.extensions
{
    static class HostExtensions
    {
        public static async Task<IHost> MigrateAsync(this IHost webHost)
        {
            using var scope = webHost.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DefaultContext>();
            await context.Database.MigrateAsync();
            return webHost;
        }
    }
}
