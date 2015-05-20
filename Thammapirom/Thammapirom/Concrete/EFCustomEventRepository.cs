using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFCustomEventRepository : ICustomEventRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<CustomEvent> CustomEvents
        {
            get { return context.CustomEvents; }
        }
        public void SaveCustomEvent(CustomEvent cev)
        {
            if (cev.cEventID == 0)
            {
                context.CustomEvents.Add(cev);
            }
            else
            {
                CustomEvent dbEntry = context.CustomEvents.Find(cev.cEventID);
                if (dbEntry != null)
                {

                    dbEntry.cEventTitle = cev.cEventTitle;
                    dbEntry.cEventDetail = cev.cEventDetail;
                    dbEntry.cEventDate = cev.cEventDate;
                    dbEntry.cEventTime = cev.cEventTime;
                    dbEntry.cEventLocation = cev.cEventLocation;
                    dbEntry.cEventPurpose = cev.cEventPurpose;
                }
            }
            context.SaveChanges();
        }
        public CustomEvent DeleteCustomEvent(int cEventID)
        {
            CustomEvent dbEntry = context.CustomEvents.Find(cEventID);
            if (dbEntry != null)
            {

                context.CustomEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}