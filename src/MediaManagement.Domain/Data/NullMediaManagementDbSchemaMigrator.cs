using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MediaManagement.Data;

/* This is used if database provider does't define
 * IMediaManagementDbSchemaMigrator implementation.
 */
public class NullMediaManagementDbSchemaMigrator : IMediaManagementDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
