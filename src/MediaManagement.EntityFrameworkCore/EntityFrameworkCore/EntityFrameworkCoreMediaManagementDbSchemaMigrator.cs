using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediaManagement.Data;
using Volo.Abp.DependencyInjection;

namespace MediaManagement.EntityFrameworkCore;

public class EntityFrameworkCoreMediaManagementDbSchemaMigrator
    : IMediaManagementDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMediaManagementDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MediaManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MediaManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}
