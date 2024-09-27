﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Service
{
    public interface IContactusElementService
    {
        List<ContactusElement> GetAllContactusElements();
        ContactusElement GetContactusElementById(int id);
        void CreateContactusElement(ContactusElement contactusElement);
        void UpdateContactusElement(ContactusElement contactusElement);
        void DeleteContactusElement(int id);
    }
}