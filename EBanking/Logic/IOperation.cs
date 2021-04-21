using System;

namespace EBanking.Logic
{
    public interface IOperation<TAccountId> where TAccountId : IEquatable<TAccountId>
    {
        public bool Execute(Account<TAccountId> acc);
    }
}