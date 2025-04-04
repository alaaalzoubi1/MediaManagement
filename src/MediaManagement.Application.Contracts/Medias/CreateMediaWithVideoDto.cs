using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

public class CreateMediaWithVideoDto
{
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public Guid MediaId { get; set; }

    public string Metadata { get; set; }

    public string SourceLanguage { get; set; }

    public string DestinationLanguage { get; set; }

    public string CountryDialect { get; set; }

    [Required]
    public IFormFile Video { get; set; }
}