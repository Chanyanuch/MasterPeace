using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;
namespace Thammapirom.Concrete
{
    public class EFBackgroundRepository : IBackgroundRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Background> Backgrounds
        {
            get { return context.Backgrounds; }
        }
        public void SaveBackgroundInfo(int backgroundID, string backgroundInfo)
        {
            Background dbEntry = context.Backgrounds.Find(backgroundID);
            if (backgroundID == 0)
            {
                dbEntry.BackgroundInfo = backgroundInfo;
                context.Backgrounds.Add(dbEntry);
            }
            else
            {
                
                if (dbEntry != null)
                {

                    dbEntry.BackgroundInfo = backgroundInfo;
                   
                }
            }
            context.SaveChanges();
        }
        public Background ClearBackgroundInfo(int backgroundID)
        {
            Background dbEntry = context.Backgrounds.Find(backgroundID);
            if (dbEntry != null)
            {
                dbEntry.BackgroundInfo = null;
                context.Backgrounds.Add(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}