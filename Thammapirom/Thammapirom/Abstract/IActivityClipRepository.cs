
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;

namespace Thammapirom.Abstract
{
    public interface IActivityClipRepository
    {
        IQueryable<ActivityClip> ActivityClips { get; }
        void SaveActivityClip(ActivityClip activityClip);
        ActivityClip DeleteActivityClip(int clipID);
    }
}
