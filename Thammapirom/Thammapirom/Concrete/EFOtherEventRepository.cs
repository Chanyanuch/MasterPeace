using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFOtherEventRepository : IEventRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<OtherEvent> OtherEvents
        {
            get { return context.OtherEvents; }
        }
        public void SaveEvent(OtherEvent evt)
        {
            if (evt.EventID == 0)
            {
                context.OtherEvents.Add(evt);
            }
            else
            {
                OtherEvent dbEntry = context.OtherEvents.Find(evt.EventID);
                if (dbEntry != null)
                {

                    dbEntry.EventTitle = evt.EventTitle;
                    dbEntry.EventDate = evt.EventDate;
                    dbEntry.EventTime = evt.EventTime;
                    dbEntry.EventLocation = evt.EventLocation;
                    dbEntry.EventPurpose = evt.EventPurpose;
                }
            }
            context.SaveChanges();
        }
        public Event DeleteEvent(int eventID)
        {
            OtherEvent dbEntry = context.OtherEvents.Find(eventID);
            if (dbEntry != null)
            {

                context.OtherEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}