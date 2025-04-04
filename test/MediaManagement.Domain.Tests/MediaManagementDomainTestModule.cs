using Volo.Abp.Modularity;

namespace MediaManagement;

[DependsOn(
    typeof(MediaManagementDomainModule),
    typeof(MediaManagementTestBaseModule)
)]
public class MediaManagementDomainTestModule : AbpModule
{

}
