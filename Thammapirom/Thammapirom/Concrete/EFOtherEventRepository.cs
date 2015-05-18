using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFOtherEventRepository : IOtherEventRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<OtherEvent> OtherEvents
        {
            get { return context.OtherEvents; }
        }
        public void SaveOtherEvent(OtherEvent oev)
        {
            oev = new OtherEvent();
            if (oev.EventID == 0)
            {
                context.OtherEvents.Add(oev);
            }
            else
            {
                OtherEvent dbEntry = context.OtherEvents.Find(oev.EventID);
                if (dbEntry != null)
                {

                    dbEntry.EventTitle = oev.EventTitle;
                    dbEntry.EventDetail = oev.EventDetail;
                    dbEntry.EventDate = oev.EventDate;
                    dbEntry.EventTime = oev.EventTime;
                    dbEntry.EventLocation = oev.EventLocation;
                    dbEntry.EventPurpose = oev.EventPurpose;
                }
            }
            context.SaveChanges();
        }
        public OtherEvent DeleteOtherEvent(int oEventID)
        {
            OtherEvent dbEntry = context.OtherEvents.Find(oEventID);
            if (dbEntry != null)
            {

                context.OtherEvents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}