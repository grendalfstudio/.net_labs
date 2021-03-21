using System;

namespace EBanking.Logic
{
    public class CheckBalanceOperation : IOperation
    {
        public bool Execute(Account acc)
        {
            Console.WriteLine($"Account {acc.AccountNumber} balance: {acc.Balance}");
            return true;
        }
    }
}