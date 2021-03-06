﻿using System;

namespace EBanking.Logic
{
    public class WithdrawOperation : IOperation<string>
    {
        private decimal _sum;
        public WithdrawOperation(decimal sum)
        {
            _sum = sum;
        }
        public bool Execute(Account<string> acc)
        {
            if (!((acc.Balance - _sum) >= 0) || _sum < 0) return false;
            acc.Balance -= _sum;
            return true;
        }
    }
}