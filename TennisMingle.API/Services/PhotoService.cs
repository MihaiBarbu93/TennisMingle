using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;
using TennisMingle.API.Interfaces;

namespace TennisMingle.API.Services
{
    public class PhotoService : IPhotoService
    {
        public Task<Photo> AddPhotoAsync(Photo photo)
        {
            throw new NotImplementedException();
        }

        public Task<Photo> DeletePhotoAsync(string photoId)
        {
            throw new NotImplementedException();
        }
    }
}
