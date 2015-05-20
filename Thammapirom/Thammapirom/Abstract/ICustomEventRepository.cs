using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;

namespace Thammapirom.Abstract
{
    public interface ICustomEventRepository
    {
        IQueryable<CustomEvent> CustomEvents { get; }
        void SaveCustomEvent(CustomEvent customEvent);
        CustomEvent DeleteCustomEvent(int cEventID);
    }
}
