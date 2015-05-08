
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;
namespace Thammapirom.Abstract
{
    public interface IGalleryImageRepository
    {
        IQueryable<GalleryImage> GalleryImages { get; }
        void SaveGalleryImage(GalleryImage galleryImage);
        GalleryImage DeleteGalleryImage(int imageID);

    }
}
