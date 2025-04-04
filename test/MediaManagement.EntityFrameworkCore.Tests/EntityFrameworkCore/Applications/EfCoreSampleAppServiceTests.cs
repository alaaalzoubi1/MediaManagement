using MediaManagement.Samples;
using Xunit;

namespace MediaManagement.EntityFrameworkCore.Applications;

[Collection(MediaManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MediaManagementEntityFrameworkCoreTestModule>
{

}
