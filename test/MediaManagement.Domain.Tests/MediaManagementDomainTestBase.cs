using Volo.Abp.Modularity;

namespace MediaManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class MediaManagementDomainTestBase<TStartupModule> : MediaManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
