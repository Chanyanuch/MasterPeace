
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;

namespace Thammapirom.Abstract
{
    public interface IDhammaQARepository
    {
        IQueryable<DhammaQA> DhammaQAs { get; }
        void SaveDhammaQA(DhammaQA dhammaQA);
        DhammaQA DeleteDhammaQA(int QAID);
    }
}
