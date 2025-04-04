using Volo.Abp.Settings;

namespace MediaManagement.Settings;

public class MediaManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MediaManagementSettings.MySetting1));
    }
}
