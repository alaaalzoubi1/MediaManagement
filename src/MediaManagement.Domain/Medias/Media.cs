using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MediaManagement.Medias
{
    public class Media : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
        public string MetaData { get; set; }
        public Guid ProjectId { get; set; } 
        public string SourceLanguage { get; set; }
        public string DestinationLanguage { get; set; }
        public string CountryDialect { get; set; }

        public Media() { }

        public Media(Guid id, string title, string description, string video, string metaData,
            Guid projectId, string sourceLanguage, string destinationLanguage, string countryDialect)
            : base(id)
        {
            Title = title;
            Description = description;
            Video = video;
            MetaData = metaData;
            ProjectId = projectId;
            SourceLanguage = sourceLanguage;
            DestinationLanguage = destinationLanguage;
            CountryDialect = countryDialect;
        }
    }
}