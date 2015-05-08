
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;
namespace Thammapirom.Abstract
{
    public interface IWelcomeImageRepository
    {
        IQueryable<WelcomeImage> WelcomeImages { get; }
       // IQueryable<GalleryImage> GalleryImages { get; }
        void SaveWelcomeImage(WelcomeImage welcomeImage);
      //  void SaveImage(GalleryImage galleryImage);
        WelcomeImage DeleteWelcomeImage(int imageID);
      //  GalleryImage DeleteImage(int imageID);
        
    }
}
