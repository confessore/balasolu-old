﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace balasolu.web.factories
{
    sealed class DefaultContextFactory<TContext> : IDbContextFactory<TContext>
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
