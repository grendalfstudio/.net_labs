using System;

namespace EBanking.Logic
{
    public class TransferMoneyOperation : IOperation<string>
    {
        private decimal _sum;
        private Account<string> _destination;

        public TransferMoneyOperation(decimal sum, Account<string> destination)
        {
            _sum = sum;
            _destination = destination;
        }

        public bool Execute(Account<string> acc)
        {
            if (!((acc.Balance - _sum) >= 0) || _sum < 0) return false;
            acc.Balance -= _sum;
            _destination.Balance += _sum;
            return true;
        }
    }
}