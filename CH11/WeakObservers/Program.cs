using Helpers;
using System;
using System.Reactive.Linq;
using System.Threading;

namespace WeakObservers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var subscription =
                Observable.Interval(TimeSpan.FromSeconds(1))
                    .AsWeakObservable()
                    .SubscribeConsole("Interval");

            Console.WriteLine("Collecting and sleeping for 2 seconds");
            GC.Collect();
            Thread.Sleep(2000); //2 seconds 

            GC.KeepAlive(subscription);
            Console.WriteLine("Done sleeping");
            Console.WriteLine("removing the strong reference, collecting and sleeping for 2 seconds");

            subscription = null;
            GC.Collect();
            Thread.Sleep(2000); //2 seconds 
            Console.WriteLine("Done sleeping");

            Console.ReadLine();
        }
    }
}
