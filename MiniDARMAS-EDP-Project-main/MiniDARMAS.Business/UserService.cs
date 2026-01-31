using MiniDARMAS.Data;
using MiniDARMAS.Models;

namespace MiniDARMAS.Business
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User? Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return _userRepository.Authenticate(username, password);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public bool CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName) || 
                string.IsNullOrWhiteSpace(user.Username) || 
                string.IsNullOrWhiteSpace(user.Password) || 
                string.IsNullOrWhiteSpace(user.Role))
                return false;

            if (_userRepository.IsUsernameExists(user.Username))
                return false;

            return _userRepository.CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName) || 
                string.IsNullOrWhiteSpace(user.Username) || 
                string.IsNullOrWhiteSpace(user.Password) || 
                string.IsNullOrWhiteSpace(user.Role))
                return false;

            if (_userRepository.IsUsernameExists(user.Username, user.UserId))
                return false;

            return _userRepository.UpdateUser(user);
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }
    }
}

