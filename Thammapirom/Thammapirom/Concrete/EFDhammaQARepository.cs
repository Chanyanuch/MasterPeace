using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFDhammaQARepository : IDhammaQARepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<DhammaQA> DhammaQAs
        {
            get { return context.DhammaQAs; }
        }
        public void SaveDhammaQA(DhammaQA dhammaQA)
        {
            if (dhammaQA.QAID == 0)
            {
                context.DhammaQAs.Add(dhammaQA);
            }
            else
            {
                DhammaQA dbEntry = context.DhammaQAs.Find(dhammaQA.QAID);
                if (dbEntry != null)
                {

                    dbEntry.Question = dhammaQA.Question;
                    dbEntry.Answer = dhammaQA.Answer;
                }
            }
            context.SaveChanges();
        }
        public DhammaQA DeleteDhammaQA(int QAID)
        {
            DhammaQA dbEntry = context.DhammaQAs.Find(QAID);
            if (dbEntry != null)
            {

                context.DhammaQAs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}