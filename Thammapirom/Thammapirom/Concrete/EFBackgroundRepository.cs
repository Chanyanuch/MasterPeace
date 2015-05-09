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
        public void SaveBackgroundInfo(Background background)
        {
            
            if (background.BackgroundID == 0)
            {
                //dbEntry.BackgroundInfo = backgroundInfo;
                context.Backgrounds.Add(background);
            }
            else
            {
                Background dbEntry = context.Backgrounds.Find(background.BackgroundID);
                if (dbEntry != null)
                {

                    dbEntry.BackgroundInfo = background.BackgroundInfo;
                   
                }
            }
            context.SaveChanges();
        }
        public Background ClearBackgroundInfo(int backgroundID)
        {
            Background dbEntry = context.Backgrounds.Find(backgroundID);
            if (dbEntry != null)
            {
                dbEntry.BackgroundInfo = "";
               
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}