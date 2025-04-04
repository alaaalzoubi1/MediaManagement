using MediaManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MediaManagement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MediaManagementController : AbpControllerBase
{
    protected MediaManagementController()
    {
        LocalizationResource = typeof(MediaManagementResource);
    }
}
