using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Repository;

namespace Trip_Volunteer.Infra.Service
{
    public class ContactusElementService: IContactusElementService
    {
        private readonly IContactusElementRepository _contactusElementRepository;
        public ContactusElementService(IContactusElementRepository contactusElementRepository)
        {
            _contactusElementRepository = contactusElementRepository;
        }
        public List<ContactusElement> GetAllContactusElements()
        {
            return _contactusElementRepository.GetAllContactusElements();
        }
        public ContactusElement GetContactusElementById(int id)
        {
            return _contactusElementRepository.GetContactusElementById(id);
        }
        public void CreateContactusElement(ContactusElement contactusElement)
        {
            _contactusElementRepository.CreateContactusElement(contactusElement);
        }
        public void UpdateContactusElement(ContactusElement contactusElement)
        {
            _contactusElementRepository.UpdateContactusElement(contactusElement);
        }
        public void DeleteContactusElement(int id)
        {
            _contactusElementRepository.DeleteContactusElement(id);
        }
        public void UpdateContactusElementSelectStatus(int id)
        {
            _contactusElementRepository.UpdateContactusElementSelectStatus(id);
        }
        public ContactusElement GetSelectedContactusElement()
        {
            return _contactusElementRepository.GetSelectedContactusElement();
        }
    }
}
