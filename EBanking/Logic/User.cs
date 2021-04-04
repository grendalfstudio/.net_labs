using System;
using System.Collections.Generic;
using System.Linq;

namespace EBanking.Logic
{
    public class User
    {
        private List<Account> _accounts;
        private Account _currAccount;

        private string _password;

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

        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public Guid CurrentAccountNumber { get; set; }

        public bool CheckPass(string pass)
        {
            return _password.Equals(pass);
        }

        public void AddAccount(string currency)
        {
            _accounts.Add(new Account(Guid.NewGuid(), currency));
        }

        public bool DoOperation(IOperation operation)
        {
            return operation.Execute(_currAccount);
        }

        public bool SelectAccount(Guid accNumber)
        {
            if (!_accounts.Exists(a => a.AccountNumber == accNumber)) return false;
            _currAccount = _accounts.Find(a => a.AccountNumber == accNumber);
            return true;
        }

        public void RemoveAccount(Guid accNumber)
        {
            var acc = _accounts.FirstOrDefault(a => a.AccountNumber.Equals(accNumber));
            if (acc is null) return;
            if (_currAccount == acc)
            {
                _currAccount = null;
            }
            _accounts.Remove(acc);
        }

        public string CheckAccounts()
        {
            return _accounts.Aggregate("", (current, account) => current + (account.AccountNumber + "\n"));
        }

        public static User operator !(User usr)
        {
            usr.RemoveAccount(usr.CurrentAccountNumber);
            return usr;
        }
    }
}