using Volo.Abp.Modularity;

namespace MediaManagement;

public abstract class MediaManagementApplicationTestBase<TStartupModule> : MediaManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
