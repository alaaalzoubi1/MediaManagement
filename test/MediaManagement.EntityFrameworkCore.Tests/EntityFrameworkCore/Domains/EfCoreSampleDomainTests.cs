using MediaManagement.Samples;
using Xunit;

namespace MediaManagement.EntityFrameworkCore.Domains;

[Collection(MediaManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MediaManagementEntityFrameworkCoreTestModule>
{

}
