using HalloSingelton;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Singleton!");


        //for (int i = 0; i < 20; i++)
        //{
        //    Task.Run(() => Logger.Instance.Info("Moin"));
        //}

        Parallel.For(0, 1_000_000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

        Logger.Instance.Error("PANIK!! Bier leer!");

        Console.ReadLine();
    }
}