namespace IntroducingRx
{
    using System;
    using System.Linq;
    using System.Reactive.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IObservable<string> strings =
                new[] { "Hello", "Rx", "A", "Ab" }.ToObservable();

            using IDisposable subscription = strings
                .Where(str => str.StartsWith("A"))
                .Select(str => str.ToUpper())
                .Subscribe(Console.WriteLine);
        }
    }
}