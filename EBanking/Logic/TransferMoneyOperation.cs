using System;

namespace EBanking.Logic
{
    public class TransferMoneyOperation : IOperation
    {
        private decimal _sum;
        private Account _destination;

        public TransferMoneyOperation(decimal sum, Account destination)
        {
            _sum = sum;
            _destination = destination;
        }

        public bool Execute(Account acc)
        {
            if (!((acc.Balance - _sum) >= 0) || _sum < 0) return false;
            acc.Balance -= _sum;
            _destination.Balance += _sum;
            return true;
        }
    }
}