using AutoMapper;
using MediaManagement.Medias;
using MediaManagement.Projects;

namespace MediaManagement;

public class MediaManagementApplicationAutoMapperProfile : Profile
{
    public MediaManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Project, ProjectDto>();
        CreateMap<CreateUpdateProjectDto, Project>();
        CreateMap<Media, MediaDto>();
        CreateMap<CreateUpdateMediaDto, Media>();
    }
}
