using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MediaManagement.Projects
{
    public interface IProjectAppService : ICrudAppService<
        ProjectDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProjectDto>
    {
        Task<List<ProjectDto>> GetUserProjectsAsync();
    }
}

