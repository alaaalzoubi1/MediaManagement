using Xunit;

namespace MediaManagement.EntityFrameworkCore;

[CollectionDefinition(MediaManagementTestConsts.CollectionDefinitionName)]
public class MediaManagementEntityFrameworkCoreCollection : ICollectionFixture<MediaManagementEntityFrameworkCoreFixture>
{

}
