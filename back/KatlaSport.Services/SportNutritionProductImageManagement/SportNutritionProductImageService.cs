using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.SportNutritionProductImageDirectory;
using DbSportNutritionProductImage = KatlaSport.DataAccess.SportNutritionProductImageDirectory.SportNutritionProductImage;

namespace KatlaSport.Services.SportNutritionProductImageManagement
{
    public class SportNutritionProductImageService : ISportNutritionProductImageService
    {
        private readonly ISportNutritionProductImageContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SportNutritionProductImageService"/> class with specified <see cref="ISportNutritionProductImageDirectoryContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="ISportNutritionProductImageDirectoryContext"/>.</param>
        public SportNutritionProductImageService(ISportNutritionProductImageContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<SportNutritionProductImageListItem>> GetSportNutritionProductImagesAsync()
        {
            var dbSportNutritionProductImage = await _context.SportNutritionProductImages.OrderBy(s => s.SportNutritionProductImageID).ToArrayAsync();
            var sportNutritionProductImages = dbSportNutritionProductImage.Select(s => Mapper.Map<SportNutritionProductImageListItem>(s)).ToList();

            return sportNutritionProductImages;
        }

        /// <inheritdoc/>
        public async Task<SportNutritionProductImage> GetSportNutritionProductImageAsync(int sportNutritionProductImageID)
        {
            var dbSportNutritionProductImage = await _context.SportNutritionProductImages.Where(p => p.SportNutritionProductImageID == sportNutritionProductImageID).ToArrayAsync();

            if (dbSportNutritionProductImage.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbSportNutritionProductImage, SportNutritionProductImage>(dbSportNutritionProductImage[0]);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionProductImage> CreateSportNutritionProductImageAsync(UpdateSportNutritionProductImageRequest createRequest)
        {
            var dbSportNutritionProductImage = Mapper.Map<UpdateSportNutritionProductImageRequest, DbSportNutritionProductImage>(createRequest);

            _context.SportNutritionProductImages.Add(dbSportNutritionProductImage);

            await _context.SaveChangesAsync();

            return Mapper.Map<SportNutritionProductImage>(dbSportNutritionProductImage);
        }

        /// <inheritdoc/>
        public async Task<SportNutritionProductImage> UpdateSportNutritionProductImageAsync(int sportNutritionProductImageID, UpdateSportNutritionProductImageRequest updateRequest)
        {
            var dbSportNutritionProductImages = await _context.SportNutritionProductImages.Where(c => c.SportNutritionProductImageID == sportNutritionProductImageID).ToArrayAsync();
            var dbSportNutritionProductImage = dbSportNutritionProductImages.FirstOrDefault();
            if (dbSportNutritionProductImage == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbSportNutritionProductImage);

            await _context.SaveChangesAsync();

            dbSportNutritionProductImages = await _context.SportNutritionProductImages.Where(c => c.SportNutritionProductImageID == sportNutritionProductImageID).ToArrayAsync();
            return dbSportNutritionProductImages.Select(c => Mapper.Map<SportNutritionProductImage>(c)).FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task DeleteSportNutritionProductImageAsync(int sportNutritionProductImageID)
        {
            var dbSportNutritionProductImages = await _context.SportNutritionProductImages.Where(c => c.SportNutritionProductImageID == sportNutritionProductImageID).ToArrayAsync();

            if (dbSportNutritionProductImages.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbSportNutritionProductImage = dbSportNutritionProductImages[0];

            _context.SportNutritionProductImages.Remove(dbSportNutritionProductImage);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<SportNutritionProductImage> UploadSportNutritionProductImageAsync(MultipartMemoryStreamProvider provider)
        {
            var dbSportNutritionProductImage = new DbSportNutritionProductImage();

            foreach (var file in provider.Contents)
            {
                dbSportNutritionProductImage.SportNutritionProductImageName = file.Headers.ContentDisposition.FileName.Trim('\"');
                dbSportNutritionProductImage.SportNutritionProductImageData = await file.ReadAsByteArrayAsync();
                dbSportNutritionProductImage.SportNutritionProductImageTitle = dbSportNutritionProductImage.SportNutritionProductImageName.Split('.')[0];
            }

            _context.SportNutritionProductImages.Add(dbSportNutritionProductImage);
            await _context.SaveChangesAsync();
            return Mapper.Map<SportNutritionProductImage>(dbSportNutritionProductImage);
        }
    }
}