using System;

namespace EBanking.Logic
{
    public class Account<TId> where TId : IEquatable<TId>
    {
        private bool Equals(Account<TId> other)
        {
            return Balance == other.Balance && Currency == other.Currency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Account<TId>)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Balance, Currency);
        }

        public Account()
        {
            AccountNumber = (TId)(Guid.NewGuid().ToString() as object);
        }

        public Account(TId accountNumber, string currency)
        {
            AccountNumber = accountNumber;
            Currency = currency;
        }

        public Account(Account<TId> acc)
        {
            Balance = acc.Balance;
            Currency = acc.Currency;
            AccountNumber = acc.AccountNumber;
        }

        public Account(TId accountNumber, decimal balance, string currency)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
            this.Currency = currency;

        }
        public TId AccountNumber { get; }
        public decimal Balance { get; set; }
        public string Currency { get; }

        public static Account<TId> operator +(Account<TId> acc, int sum)
        {
            if (sum < 0) throw new ArgumentException("Sum must be non negative");
            acc.Balance += sum;
            return acc;
        }

        public static Account<TId> operator -(Account<TId> acc, int sum)
        {
            if (sum < 0) throw new ArgumentException("Sum must be non negative");
            acc.Balance -= sum;
            return acc;
        }

        public static Account<TId> operator ++(Account<TId> acc)
        {
            ++acc.Balance;
            return acc;
        }

        public static Account<TId> operator --(Account<TId> acc)
        {
            --acc.Balance;
            return acc;
        }

        public static bool operator <(Account<TId> acc1, Account<TId> acc2)
        {
            if (!acc1.Currency.Equals(acc2.Currency))
                throw new InvalidOperationException("Can't compare accounts with different currencies");
            return acc1.Balance < acc2.Balance;
        }

        public static bool operator >(Account<TId> acc1, Account<TId> acc2)
        {
            if (!acc1.Currency.Equals(acc2.Currency))
                throw new InvalidOperationException("Can't compare accounts with different currencies");
            return acc1.Balance > acc2.Balance;
        }

        public static bool operator ==(Account<TId> acc1, Account<TId> acc2)
        {
            return acc1.Currency.Equals(acc2.Currency) && acc1.Balance == acc2.Balance;
        }

        public static bool operator !=(Account<TId> acc1, Account<TId> acc2)
        {
            return !(acc1.Currency.Equals(acc2.Currency) && acc1.Balance == acc2.Balance);
        }
    }
}