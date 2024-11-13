using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.Infra.Service
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public void CreateContact(ContactU contact)
        {
            _contactUsRepository.CreateContact(contact);
        }

        public void DeleteContact(int contactId)
        {
            _contactUsRepository.DeleteContact(contactId);
        }

        public List<ContactU> GetAllContacts()
        {
           return _contactUsRepository.GetAllContacts();
        }

        public ContactU GetContactById(int contactId)
        {
            return _contactUsRepository.GetContactById(contactId);
        }

        public void UpdateContact(ContactU contact)
        {
            _contactUsRepository.UpdateContact(contact);
        }


    }
}
