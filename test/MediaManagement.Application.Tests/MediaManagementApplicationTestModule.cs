using Volo.Abp.Modularity;

namespace MediaManagement;

[DependsOn(
    typeof(MediaManagementApplicationModule),
    typeof(MediaManagementDomainTestModule)
)]
public class MediaManagementApplicationTestModule : AbpModule
{

}
