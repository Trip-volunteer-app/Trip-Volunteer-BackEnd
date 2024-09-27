using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IContactUsService
    {
        List<ContactU> GetAllContacts();
        ContactU GetContactById(int contactId);
        void CreateContact(ContactU contact);
        void UpdateContact(ContactU contact);
        void DeleteContact(int contactId);
    }
}
