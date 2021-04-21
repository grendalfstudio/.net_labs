using System;
using EBanking.Logic;

namespace EBanking
{
    public static class CtorsTest
    {
        public static void Test()
        {
            Account<string> acc2 = new(Guid.NewGuid().ToString(), "UAH");
            Account<string> acc1 = new();
            Account<string> acc3 = new(acc2);

            User usr1 = new();
            UserManager.CreateUser("Name", "SName", "sspass");
            User usr2 = new(usr1);
        }
    }
}