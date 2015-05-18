using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFAnnualEventRepository : IEventRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<AnnualEvent> AnnualEvents
        {
            get { return context.AnnualEvents; }
        }
        public void SaveEvent(AnnualEvent evt)
        {
            if (evt.EventID == 0)
            {
                context.AnnualEvents.Add(evt);
            }
            else
            {
                Event dbEntry = context.AnnualEvents.Find(evt.EventID);
                if (dbEntry != null)
                {

                    dbEntry.EventTitle = evt.EventTitle;
                    dbEntry.EventDate = evt.EventDate;
                    dbEntry.EventTime = evt.EventTime;
                    dbEntry.EventLocation = evt.EventLocation;
                }
            }
            context.SaveChanges();
        }
        public Event DeleteEvent(int eventID)
        {
            AnnualEvent dbEntry = context.AnnualEvents.Find(eventID);
            if (dbEntry != null)
            {

                context.AnnualEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}