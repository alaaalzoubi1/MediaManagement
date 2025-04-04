using System;
using Volo.Abp.Application.Dtos;

namespace MediaManagement.Projects
{
    public class ProjectDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}