using System.Threading.Tasks;

namespace MediaManagement.Data;

public interface IMediaManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
