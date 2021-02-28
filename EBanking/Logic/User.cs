using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace EBanking.Logic
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        private string _password;
        private List<Account> _accounts;
        private Account _curAccount;

        public User()
        {
            Id = -1;
            Name = "Invalid user";
            Console.WriteLine($"{GetType().Name} default ctor called");
        }
        public User(int id, string name, string surname, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            _password = password;
            
            Console.WriteLine($"{GetType().Name} initializer ctor called");
        }

        public User(User usr)
        {
            Id = usr.Id;
            Name = usr.Name;
            Surname = usr.Surname;
            _password = usr._password;
            _accounts = usr._accounts;
            
            Console.WriteLine($"{GetType().Name} copy ctor called");
        }

        public bool CheckPass(string pass)
        {
            return _password.Equals(pass);
        }
    }
}