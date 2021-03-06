﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EBanking.Logic
{
    public class User : AbstractUser<string>
    {


        public User()
        {
            Notify += WriteMessage;
        }

        public User(int id, string name, string surname, string password) : base(id, name, surname, password)
        {
            Notify += WriteMessage;
        }

        public User(AbstractUser<string> usr) : base(usr)
        {
            Notify += WriteMessage;
        }

        public delegate void AccountHandler(string message);

        public event AccountHandler Notify;

        public override bool CheckPass(string pass)
        {
            return _password.Equals(pass);
        }

        public override void AddAccount(string currency)
        {
            _accounts.Add(new Account<string>((string)(Guid.NewGuid().ToString() as object), currency));
            _currAccount = _accounts.Last();
            CurrentAccountNumber = _currAccount.AccountNumber;
            Notify?.Invoke($"Account {_currAccount.AccountNumber} created");
        }

        public override void AddAccount(Account<string> acc)
        {
            _accounts.Add(acc);
            _currAccount = acc;
            CurrentAccountNumber = _currAccount.AccountNumber;
        }

        public bool SelectAccount(string accNumber)
        {
            if (!_accounts.Exists(a => a.AccountNumber.Equals(accNumber))) return false;
            _currAccount = _accounts.Find(a => a.AccountNumber.Equals(accNumber));
            CurrentAccountNumber = _currAccount.AccountNumber;
            return true;
        }

        public void RemoveAccount(string accNumber)
        {
            var acc = _accounts.FirstOrDefault(a => a.AccountNumber.Equals(accNumber));
            if (acc is null) return;
            if (_currAccount == acc)
            {
                _currAccount = null;
            }
            _accounts.Remove(acc);
            Notify?.Invoke($"Account {acc.AccountNumber} deleted");
        }

        public string CheckAccounts()
        {
            Func<string, Account<string>, string> func = delegate (string current, Account<string> account)
            {
                return current + (account.AccountNumber + "\n");
            };

            return _accounts.Aggregate("", func);
        }

        public static User operator !(User usr)
        {
            usr.RemoveAccount(usr.CurrentAccountNumber);
            return usr;
        }

        private void WriteMessage(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}