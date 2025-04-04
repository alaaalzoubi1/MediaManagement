using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MediaManagement.Projects
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Project() { }

        public Project(Guid id, string title, string description)
            : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}