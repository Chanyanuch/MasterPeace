using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFActivityClipRepository : IActivityClipRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<ActivityClip> ActivityClips
        {
            get { return context.ActivityClips; }
        }
        public void SaveActivityClip(ActivityClip activityClip)
        {
            if (activityClip.ClipID == 0)
            {
                context.ActivityClips.Add(activityClip);
            }
            else
            {
                ActivityClip dbEntry = context.ActivityClips.Find(activityClip.ClipID);
                if (dbEntry != null)
                {

                    dbEntry.ClipTitle = activityClip.ClipTitle;
                    dbEntry.ClipEmbedCode = activityClip.ClipEmbedCode;
                }
            }
            context.SaveChanges();
        }
        public ActivityClip DeleteActivityClip(int clipID)
        {
            ActivityClip dbEntry = context.ActivityClips.Find(clipID);
            if (dbEntry != null)
            {

                context.ActivityClips.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}