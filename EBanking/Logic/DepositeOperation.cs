using System;

namespace EBanking.Logic
{
    public class DepositeOperation : IOperation<string>
    {
        private decimal _sum;

        public DepositeOperation(decimal sum)
        {
            _sum = sum;
        }

        public bool Execute(Account<string> acc)
        {
            if (_sum < 0) return false;
            acc.Balance += _sum;
            return true;
        }
    }
}