using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads_in_Csharp
{
    /// <summary>
    /// This is a classic example of thread-safe
    /// 
    /// This example shows a bank account that cannot have 0 or less balance, so we have a lock 
    /// with an object inside the method, other threads cannot execute the code when some thread
    /// is with the object resource (acctLock). It must wait until the first thread is done with its
    /// processing. The lock keyword works by invoking Monitor.Enter (and subsequently Monitor.Exit) on the runtime.
    /// </summary>
    public class ThreadSleep
    {
        //static void Main(string[] args)
        //{
        //    Thread.CurrentThread.Name = "Main";
        //    Console.WriteLine($"-- '{Thread.CurrentThread.Name}' is with status " +
        //        $"'{Thread.CurrentThread.ThreadState}' --\n");

        //    BankAccount acc = new BankAccount(2);
 
        //    Thread t = new Thread(new ThreadStart(acc.IssueWithdraw));
        //    t.Name = "First Operation";
        //    t.Start();

        //    Thread t2 = new Thread(new ThreadStart(acc.IssueWithdraw));
        //    t2.Name = "Second Operation";
        //    t2.Start();
        //    t2.Join(); //Join is used mainly when you need to wait that a thread 
        //               //(or a bunch of them) will terminate before proceding with your code. 
        //               //if you comment the line the 't2.Join()'.. it will not wait for t1 to be completed

        //    Thread t3 = new Thread(new ThreadStart(acc.IssueWithdraw));
        //    t3.Name = "Third Operation";
        //    t3.Start(); //this thread will start anytime, but just when t and t2 terminate.. the main thread remains 

            
        //    Console.WriteLine($"\n-- '{Thread.CurrentThread.Name}' Thread Ended --");
        //    Console.ReadKey();
        //}
    }


    public class BankAccount
    {
        private Object acctLock = new object();
        public double Balance;

        public BankAccount(double Balance)
        {
            this.Balance = Balance;
        }

        public double Withdraw(double amount)
        {
            
            if ((Balance - amount) < 0)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}.. Sry, ${Balance} in Account");
                return Balance;
            }

            else
            {
                lock (acctLock) //explanation on the class summary
                {
                    if (Balance >= amount)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name} Removed {amount} and {Balance - amount} left in Account");

                        Balance -= amount;
                    }

                    return Balance;
                }
            }
        }

        public void IssueWithdraw()
        {
            Withdraw(1);
        }
    }
}
