using DataAccess.Interfaces;
using Entities.Concrete;
using Infrastructure.Helper;
using Infrastructure.Utilities.Results;
using Services.Constants;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class PhotoService : IPhotoService
    {
        IPhotoDal _photoDal;
        public PhotoService(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }
        public async Task<Result> AddAsync(PhotoModel model)
        {
            var photo = new Photo
            {
                Name = model.Name,
                Jpeg = JpegHelper.JpegCompress(model.Photo,model.CompressionLevel)
            };
            await _photoDal.AddAsync(photo);
            return new SuccessResult(Messages.AddedPhoto);
        }

        public async Task<DataResult<IList<Photo>>> GetAllAsync()
        {
            var data = await _photoDal.GetListAsync();
            data = data.Select(x => 
                new Photo 
                {
                    Id= x.Id,
                    Name = x.Name,Jpeg= JpegHelper.JpegDeCompress(x.Jpeg)
                }
            ).ToList();
            return new SuccessDataResult<IList<Photo>>(data,Messages.SuccessfulList);
        }
    }
}
