
using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;
namespace Thammapirom.Concrete
{
    public class EFGalleryImageRepository : IGalleryImageRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<GalleryImage> GalleryImages
        {
            get { return context.GalleryImages; }
        }
        public void SaveGalleryImage(GalleryImage galleryImage)
        {
            if (galleryImage.ImageID == 0)
            {
                context.GalleryImages.Add(galleryImage);
            }
            else
            {
                GalleryImage dbEntry = context.GalleryImages.Find(galleryImage.ImageID);
                if (dbEntry != null)
                {

                    dbEntry.ImageData = galleryImage.ImageData;
                }
            }
            context.SaveChanges();
        }
        public GalleryImage DeleteGalleryImage(int imageID)
        {
            GalleryImage dbEntry = context.GalleryImages.Find(imageID);
            if (dbEntry != null)
            {

                context.GalleryImages.Remove(dbEntry);
                context.SaveChanges();   
            }
            return dbEntry;
        }
        
    }
}
    