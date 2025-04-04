using System;
using System.ComponentModel.DataAnnotations;

namespace MediaManagement.Medias
{
    public class CreateUpdateMediaDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Video { get; set; }

        public string MetaData { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public string SourceLanguage { get; set; }

        [Required]
        public string DestinationLanguage { get; set; }

        public string CountryDialect { get; set; }
    }
}