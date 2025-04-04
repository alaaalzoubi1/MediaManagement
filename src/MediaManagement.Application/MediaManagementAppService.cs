using MediaManagement.Localization;
using Volo.Abp.Application.Services;

namespace MediaManagement;

/* Inherit your application services from this class.
 */
public abstract class MediaManagementAppService : ApplicationService
{
    protected MediaManagementAppService()
    {
        LocalizationResource = typeof(MediaManagementResource);
    }
}
