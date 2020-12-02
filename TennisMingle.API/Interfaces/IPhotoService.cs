using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.API.Interfaces
{
    interface IPhotoService
    {
        Task<Photo> AddPhotoAsync(Photo photo);
        Task<Photo> DeletePhotoAsync(string photoId);
    }
}
