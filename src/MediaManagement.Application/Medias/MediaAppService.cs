using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using Volo.Abp.Http; 
namespace MediaManagement.Medias
{
    public class MediaAppService : CrudAppService<
            Media, MediaDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMediaDto>,
        IMediaAppService
    {
        private readonly IRepository<Media, Guid> _repository;
        private readonly IHostEnvironment _environment;
        private readonly ICurrentUser _currentUser;
        private readonly IBlobContainer _blobContainer;
        public MediaAppService(IRepository<Media, Guid> repository, IHostEnvironment environment, ICurrentUser currentUser, IBlobContainer blobContainer)
            : base(repository)
        {
            _repository = repository;
            _environment = environment;
            _currentUser = currentUser;
            _blobContainer = blobContainer;
        }


        public async Task<List<MediaDto>> GetProjectMediasAsync(Guid projectId)
        {
            var medias = await _repository.GetListAsync(m => m.ProjectId == projectId);
            return ObjectMapper.Map<List<Media>, List<MediaDto>>(medias);
        }
       


        public async Task<MediaDto> UploadVideoAsync(Guid mediaId, IFormFile video)
        {
            var media = await _repository.FindAsync(mediaId);
            if (media == null)
                throw new UserFriendlyException("Media not found.");

            if (video == null || video.Length == 0)
                throw new UserFriendlyException("A video file must be provided.");

            var blobName = $"{Guid.NewGuid()}_{video.FileName}";
            await _blobContainer.SaveAsync(blobName, video.OpenReadStream(), overrideExisting: true);

            media.Video = blobName;
            await _repository.UpdateAsync(media);

            return ObjectMapper.Map<Media, MediaDto>(media);
        }


        
        // public async Task<IRemoteStreamContent> DownloadVideoAsync(Guid mediaId)
        // {
        //     var media = await _repository.GetAsync(mediaId);
        //     if (media == null || string.IsNullOrEmpty(media.Video))
        //     {
        //         throw new FileNotFoundException("Video not found.");
        //     }
        //
        //     var stream = File.OpenRead(media.Video);
        //     var fileName = Path.GetFileName(media.Video);
        //
        //     return new RemoteStreamContent(stream, fileName, "video/mp4");
        // }
        public async Task<IRemoteStreamContent> DownloadVideoAsync(Guid mediaId)
        {
            var media = await _repository.GetAsync(mediaId);
            if (media == null || string.IsNullOrEmpty(media.Video))
            {
                throw new FileNotFoundException("Video not found.");
            }

            var stream = await _blobContainer.GetAsync(media.Video);
            var fileName = Path.GetFileName(media.Video);

            return new RemoteStreamContent(stream, fileName, "video/mp4");
        }


    }
}
