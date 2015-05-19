
using System.Linq;
using Thammapirom.Models;
using Thammapirom.Concrete;
namespace Thammapirom.Abstract
{
    public interface IContactRepository
    {
        IQueryable<Contact> Contacts { get; }
        void SaveContact(Contact contact);
        Contact DeleteContact(int contactID);
    }
}
