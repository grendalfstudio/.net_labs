using System;

namespace EBanking.Logic
{
    public class OperatorsTest
    {

        public OperatorsTest()
        {
            FirstAccount = new(Guid.NewGuid().ToString(), "UAH");
            SecondAccount = new(Guid.NewGuid().ToString(), "UAH");

            User = new User();
        }

        public Account<string> FirstAccount { get; set; }
        public Account<string> SecondAccount { get; set; }
        public User User { get; set; }

        public void Run()
        {
            User.AddAccount(FirstAccount);
            User.AddAccount(SecondAccount);

            SecondAccount.Balance = 1488;

            Console.WriteLine("\n#### Оператор '!' ####");
            Console.WriteLine("Аккаунти до виклику оператора:");
            Console.WriteLine(User.CheckAccounts());
            User = !User;
            Console.WriteLine("Аккаунти після виклику оператора:");
            Console.WriteLine((User as User).CheckAccounts());
            
            Console.WriteLine("\n#### Оператор '++' ####");
            Console.WriteLine("Баланс до виклику оператора:");
            Console.WriteLine(FirstAccount.Balance);
            ++FirstAccount;
            Console.WriteLine("Баланс після виклику оператора:");
            Console.WriteLine(FirstAccount.Balance);
            
            Console.WriteLine("\n#### Оператор '+' ####");
            Console.WriteLine("Баланс до виклику оператора:");
            Console.WriteLine(FirstAccount.Balance);
            FirstAccount = FirstAccount + 227;
            Console.WriteLine("Баланс після виклику оператора:");
            Console.WriteLine(FirstAccount.Balance);
            
            Console.WriteLine("\n#### Оператор '>' ####");
            Console.WriteLine("Баланси на аккаунтах:");
            Console.WriteLine(FirstAccount.Balance);
            Console.WriteLine(SecondAccount.Balance);
            Console.WriteLine("Виклик оператора [FirstAccount > SecondAccount]:");
            Console.WriteLine(FirstAccount > SecondAccount);
            System.Console.WriteLine();

        }
    }
}