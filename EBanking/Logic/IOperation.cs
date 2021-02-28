namespace EBanking.Logic
{
    public interface IOperation
    {
        public bool Execute(Account acc);
    }
}