
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;
namespace Thammapirom.Abstract
{
    public interface IWelcomeImageRepository
    {
        IQueryable<WelcomeImage> WelcomeImages { get; }
        void SaveWelcomeImage(WelcomeImage welcomeImage);
        WelcomeImage DeleteWelcomeImage(int imageID);
    }
}
