using Microsoft.EntityFrameworkCore;

namespace balasolu.factories
{
    public sealed class DefaultContextFactory<TContext> : IDbContextFactory<TContext>
        where TContext : DbContext
    {
        readonly IServiceProvider _serviceProvider;

        public DefaultContextFactory(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TContext CreateDbContext()
        {
            if (_serviceProvider == null)
            {
                throw new InvalidOperationException(
                    $"You must configure an instance of IServiceProvider");
            }
            return ActivatorUtilities.CreateInstance<TContext>(_serviceProvider);
        }
    }
}
