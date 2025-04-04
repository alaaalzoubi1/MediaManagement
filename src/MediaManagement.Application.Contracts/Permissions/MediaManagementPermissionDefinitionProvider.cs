using MediaManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace MediaManagement.Permissions;

public class MediaManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MediaManagementPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(MediaManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MediaManagementResource>(name);
    }
}
