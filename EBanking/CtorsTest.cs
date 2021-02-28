using System;
using EBanking.Logic;

namespace EBanking
{
    public static class CtorsTest
    {
        public static void Test()
        {
            Account acc1 = new();
            Account acc2 = new(Guid.NewGuid(), "UAH");
            Account acc3 = new(acc2);

            User usr1 = new();
            UserManager.CreateUser("Name", "SName", "sspass");
            User usr2 = new(usr1);
        }
    }
}