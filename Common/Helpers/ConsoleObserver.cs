namespace Helpers
{
    using System;

    public class ConsoleObserver<T> : IObserver<T>
    {
        private readonly string _name;

        public ConsoleObserver(string name = "")
        {
            _name = name;
        }

        public void OnNext(T value)
        {
            Console.WriteLine($"{_name} - OnNext({value})");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{_name} - OnError:");
            Console.WriteLine($"\t {error.Message}");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"{_name} - OnCompleted()");
        }
    }
}