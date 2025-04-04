using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using MediaManagement.Permissions;
using Volo.Abp.Application.Dtos;

namespace MediaManagement.Projects
{
    public class ProjectAppService : 
        CrudAppService<
            Project,
            ProjectDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProjectDto>,
        IProjectAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<Project, Guid> _repository;

        public ProjectAppService(IRepository<Project, Guid> repository, ICurrentUser currentUser)
            : base(repository)
        {
            _currentUser = currentUser;
            _repository = repository;
        }

        public async Task<List<ProjectDto>> GetUserProjectsAsync()
        {
            if (!_currentUser.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var projects = await _repository.GetListAsync(p => p.CreatorId == _currentUser.Id);
            return ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects);
        }
    }
}
