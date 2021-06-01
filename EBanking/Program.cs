using System;

namespace EBanking
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //TODO: delete this before release
            const string str = "======Лабораторна робота №1======\n" +
                               "=Виконали студенти групи IТ-81: =\n" +
                               "=Краснова Полiна IТ-8111        =\n" +
                               "=Васкевич Микола IТ-8103        =\n" +
                               "=Пустовєтов Павло IТ-8119       =\n" +
                               "=Юхимчук Анастасiя IТ-8128      =\n" +
                               "=================================\n";
            Console.WriteLine(str);

            CtorsTest.Test();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}