using System.Collections.Generic;
using System.Linq;

namespace EBanking.Logic
{
    public static class UserManager
    {
        private static List<User> _users = new();
        private static User _currentUser = new();
        private static int _lastId;

        public static int CreateUser(string name, string sName, string pass)
        {
            if ((name is null or "") || (sName is null or "") || (pass is null or ""))
            {
                throw new RegistrationException("Invalid input");
            }
            User usr = new(_lastId++, name, sName, pass);
            _users.Add(usr);
            return usr.Id;
        }

        public static bool AuthenticateUser(int id, string pass)
        {
            if (!_users.Exists(u => u.Id == id) || !_users.First(u => u.Id == id).CheckPass(pass))
                throw new AuthenticationException("Invalid login/password");
            _currentUser = _users.First(u => u.Id == id);
            return true;
        }
    }
}