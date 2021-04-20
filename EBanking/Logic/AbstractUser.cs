using System;
using System.Collections.Generic;

namespace EBanking.Logic
{
    public abstract class AbstractUser<TAccountId> where TAccountId : IEquatable<TAccountId>
    {
        protected List<Account<TAccountId>> _accounts = new List<Account<TAccountId>>();
        protected Account<TAccountId> _currAccount;

        protected string _password;

        public AbstractUser()
        {
            Id = -1;
            Name = "Invalid user";
            Console.WriteLine($"{GetType().Name} default ctor called");
        }

        public AbstractUser(int id, string name, string surname, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            _password = password;

            Console.WriteLine($"{GetType().Name} initializer ctor called");
        }

        public AbstractUser(AbstractUser<TAccountId> usr)
        {
            Id = usr.Id;
            Name = usr.Name;
            Surname = usr.Surname;
            _password = usr._password;
            _accounts = usr._accounts;

            Console.WriteLine($"{GetType().Name} copy ctor called");
        }

        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public TAccountId CurrentAccountNumber { get; set; }

        public abstract bool CheckPass(string pass);

        public abstract void AddAccount(string currency);

        public abstract void AddAccount(Account<TAccountId> acc);
        
    }
}