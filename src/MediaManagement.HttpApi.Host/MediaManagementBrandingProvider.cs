using Microsoft.Extensions.Localization;
using MediaManagement.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MediaManagement;

[Dependency(ReplaceServices = true)]
public class MediaManagementBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<MediaManagementResource> _localizer;

    public MediaManagementBrandingProvider(IStringLocalizer<MediaManagementResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
