
using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;
namespace Thammapirom.Concrete
{
    public class EFWelcomeImageRepository : IWelcomeImageRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<WelcomeImage> WelcomeImages
        {
            get { return context.WelcomeImages; }
        }
        public void SaveWelcomeImage(WelcomeImage welcomeImage)
        {
            if (welcomeImage.ImageID == 0)
            {
                context.WelcomeImages.Add(welcomeImage);
            }
            else
            {
                WelcomeImage dbEntry = context.WelcomeImages.Find(welcomeImage.ImageID);
                if (dbEntry != null)
                {
                   
                    dbEntry.ImageData = welcomeImage.ImageData;
                }
            }
            context.SaveChanges();
        }
        public WelcomeImage DeleteWelcomeImage(int imageID)
        {
            WelcomeImage dbEntry = context.WelcomeImages.Find(imageID);
            if (dbEntry != null)
            {
                
                context.WelcomeImages.Remove(dbEntry);
                context.SaveChanges();   
            }
            return dbEntry;
        }
        
    }
}
    