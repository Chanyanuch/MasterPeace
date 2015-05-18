
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;


namespace Thammapirom.Abstract
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; }
        void SaveEvent(Event evt);
        Event DeleteEvent(int eventID);
    }
}
