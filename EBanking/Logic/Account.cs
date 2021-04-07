using System;

namespace EBanking.Logic
{
    public class Account
    {
        private bool Equals(Account other)
        {
            return Balance == other.Balance && Currency == other.Currency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Account) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Balance, Currency);
        }

        public Account()
        {
            AccountNumber = Guid.NewGuid();
            Console.WriteLine($"{GetType().Name} default ctor called");
        }

        public Account(Guid accountNumber, string currency)
        {
            AccountNumber = accountNumber;
            Currency = currency;

            Console.WriteLine($"{GetType().Name} initializer ctor called");
        }

        public Account(Account acc)
        {
            Balance = acc.Balance;
            Currency = acc.Currency;
            AccountNumber = acc.AccountNumber;

            Console.WriteLine($"{GetType().Name} copy ctor called");
        }

        public Guid AccountNumber { get; }
        public decimal Balance { get; set; }
        public string Currency { get; }

        public static Account operator +(Account acc, int sum)
        {
            if (sum < 0) throw new ArgumentException("Sum must be non negative");
            acc.Balance += sum;
            return acc;
        }
        
        public static Account operator -(Account acc, int sum)
        {
            if (sum < 0) throw new ArgumentException("Sum must be non negative");
            acc.Balance -= sum;
            return acc;
        }

        public static Account operator ++(Account acc)
        {
            ++acc.Balance;
            return acc;
        }
        
        public static Account operator --(Account acc)
        {
            --acc.Balance;
            return acc;
        }

        public static bool operator <(Account acc1, Account acc2)
        {
            if (!acc1.Currency.Equals(acc2.Currency)) 
                throw new InvalidOperationException("Can't compare accounts with different currencies");
            return acc1.Balance < acc2.Balance;
        }
        
        public static bool operator >(Account acc1, Account acc2)
        {
            if (!acc1.Currency.Equals(acc2.Currency)) 
                throw new InvalidOperationException("Can't compare accounts with different currencies");
            return acc1.Balance > acc2.Balance;
        }
        
        public static bool operator ==(Account acc1, Account acc2)
        {
            return acc1.Currency.Equals(acc2.Currency) && acc1.Balance == acc2.Balance;
        }
        
        public static bool operator !=(Account acc1, Account acc2)
        {
            return !(acc1.Currency.Equals(acc2.Currency) && acc1.Balance == acc2.Balance);
        }
    }
}