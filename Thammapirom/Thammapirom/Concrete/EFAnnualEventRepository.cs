using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFAnnualEventRepository : IAnnualEventRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<AnnualEvent> AnnualEvents
        {
            get { return context.AnnualEvents; }
        }
        public void SaveAnnualEvent(AnnualEvent aev)
        {
            if (aev.aEventID == 0)
            {
                context.AnnualEvents.Add(aev);
            }
            else
            {
                AnnualEvent dbEntry = context.AnnualEvents.Find(aev.aEventID);
                if (dbEntry != null)
                {

                    dbEntry.aEventTitle = aev.aEventTitle;
                    dbEntry.aEventDetail = aev.aEventDetail;
                    dbEntry.aEventDate = aev.aEventDate;
                    dbEntry.aEventTime = aev.aEventTime;
                    dbEntry.aEventLocation = aev.aEventLocation;
                }
            }
            context.SaveChanges();
        }
        public AnnualEvent DeleteAnnualEvent(int aEventID)
        {
            AnnualEvent dbEntry = context.AnnualEvents.Find(aEventID);
            if (dbEntry != null)
            {

                context.AnnualEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}