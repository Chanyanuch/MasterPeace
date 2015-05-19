
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;


namespace Thammapirom.Abstract
{
    public interface IOtherEventRepository
    {
        IQueryable<OtherEvent> OtherEvents { get; }
        void SaveOtherEvent(OtherEvent oev);
        OtherEvent DeleteOtherEvent(int oEventID);
    }
}
