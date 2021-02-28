using System;

namespace EBanking.Logic
{
    public class Account
    {
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
        public decimal Balance { get; set; } = 0;
        public string Currency { get; }

        public bool DoOperation(IOperation operation)
        {
            return operation.Execute(this);
        }
    }
}