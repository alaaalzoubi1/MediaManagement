using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace MediaManagement.Medias
{
    public interface IMediaAppService : ICrudAppService<
        MediaDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMediaDto>
    {
        Task<List<MediaDto>> GetProjectMediasAsync(Guid projectId);
        Task<MediaDto> UploadVideoAsync(Guid mediaTd, IFormFile video);
        Task<IRemoteStreamContent> DownloadVideoAsync(Guid mediaId);

    }
}