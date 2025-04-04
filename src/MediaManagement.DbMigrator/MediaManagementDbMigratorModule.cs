using MediaManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MediaManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MediaManagementEntityFrameworkCoreModule),
    typeof(MediaManagementApplicationContractsModule)
)]
public class MediaManagementDbMigratorModule : AbpModule
{
}
