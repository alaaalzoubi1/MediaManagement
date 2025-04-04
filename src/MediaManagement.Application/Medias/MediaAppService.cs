using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
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

        public MediaAppService(IRepository<Media, Guid> repository, IHostEnvironment environment, ICurrentUser currentUser)
            : base(repository)
        {
            _repository = repository;
            _environment = environment;
            _currentUser = currentUser;
        }


        public async Task<List<MediaDto>> GetProjectMediasAsync(Guid projectId)
        {
            var medias = await _repository.GetListAsync(m => m.ProjectId == projectId);
            return ObjectMapper.Map<List<Media>, List<MediaDto>>(medias);
        }
       


        public async Task<MediaDto> UploadVideoAsync(Guid mediaId, IFormFile video)
        {
            if (video == null || video.Length == 0)
                throw new ArgumentException("Invalid video file.");

            if (!_currentUser.IsAuthenticated)
                throw new UnauthorizedAccessException("User is not authenticated.");

            var fileName = $"{Guid.NewGuid()}_{video.FileName}";
            var uploadPath = Path.Combine(_environment.ContentRootPath, "uploads/videos");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await video.CopyToAsync(stream);
            }

            var media = await _repository.GetAsync(mediaId);

            await _repository.UpdateAsync(media);
            media.Video = filePath;
            return ObjectMapper.Map<Media, MediaDto>(media);
        }

        
        public async Task<IRemoteStreamContent> DownloadVideoAsync(Guid mediaId)
        {
            var media = await _repository.GetAsync(mediaId);
            if (media == null || string.IsNullOrEmpty(media.Video))
            {
                throw new FileNotFoundException("Video not found.");
            }

            var stream = File.OpenRead(media.Video);
            var fileName = Path.GetFileName(media.Video);

            return new RemoteStreamContent(stream, fileName, "video/mp4");
        }
    }
}
