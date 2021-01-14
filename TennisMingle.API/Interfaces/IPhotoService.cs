using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddMemberPhotoAsync(IFormFile file);
        Task<ImageUploadResult> AddTennisClubPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
