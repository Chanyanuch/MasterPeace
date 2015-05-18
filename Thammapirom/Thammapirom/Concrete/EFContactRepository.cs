using System.Linq;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Data.Objects;
using System;

namespace Thammapirom.Concrete
{
    public class EFContactRepository : IContactRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Contact> Contacts
        {
            get { return context.Contacts; }
        }
        public void SaveContact(Contact contact)
        {
            if (contact.ContactID == 0)
            {
                context.Contacts.Add(contact);
            }
            else
            {
                Contact dbEntry = context.Contacts.Find(contact.ContactID);
                if (dbEntry != null)
                {

                    dbEntry.Sender = contact.Sender;
                    dbEntry.SenderEmail = contact.SenderEmail;
                    dbEntry.ContactTitle = contact.ContactTitle;
                    dbEntry.ContactMessage = contact.ContactMessage;
                   
                }
            }
            context.SaveChanges();
        }
        public Contact DeleteContact(int contactID)
        {
            Contact dbEntry = context.Contacts.Find(contactID);
            if (dbEntry != null)
            {

                context.Contacts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}