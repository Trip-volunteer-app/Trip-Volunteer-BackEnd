using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Data;

namespace Trip_Volunteer.Core.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUsersById(int id);
        void CreateUsers(User user);
        void UpdateUsers(User user);
        void DeleteUsers(int id);

    }
}
