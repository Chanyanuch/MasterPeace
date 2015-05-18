using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;

namespace Thammapirom.Abstract
{
    public interface IAnnualEventRepository
    {
        IQueryable<AnnualEvent> AnnualEvents { get; }
        void SaveAnnualEvent(AnnualEvent aev);
        AnnualEvent DeleteAnnualEvent(int aEventID);
    }
}
