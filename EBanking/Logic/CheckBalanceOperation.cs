using System;

namespace EBanking.Logic
{
    public class CheckBalanceOperation : IOperation<string>
    {
        public bool Execute(Account<string> acc)
        {
            Console.WriteLine($"Account {acc.AccountNumber} balance: {acc.Balance}");
            return true;
        }
    }
}