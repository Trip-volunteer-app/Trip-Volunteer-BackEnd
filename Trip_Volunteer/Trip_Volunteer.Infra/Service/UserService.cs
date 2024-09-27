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
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public User GetUsersById(int id)
        {
            return _userRepository.GetUsersById(id);
        }
        public void CreateUsers(User user)
        {
            _userRepository.CreateUsers(user);
        }
        public void UpdateUsers(User user)
        {
            _userRepository.UpdateUsers(user);
        }
        public void DeleteUsers(int id)
        {
            _userRepository.DeleteUsers(id);
        }
    }
}
