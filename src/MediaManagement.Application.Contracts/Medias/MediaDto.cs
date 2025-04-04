using System;
using Volo.Abp.Application.Dtos;

namespace MediaManagement.Medias
{
    public class MediaDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
        public string MetaData { get; set; }
        public Guid ProjectId { get; set; }
        public string SourceLanguage { get; set; }
        public string DestinationLanguage { get; set; }
        public string CountryDialect { get; set; }
    }
}