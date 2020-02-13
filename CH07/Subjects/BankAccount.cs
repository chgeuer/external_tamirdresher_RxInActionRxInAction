using System;
using System.Reactive.Subjects;

namespace Subjects
{
    internal class BankAccount
    {
        private readonly Subject<int> _inner = new Subject<int>();

        public IObservable<int> MoneyTransactions { get { return _inner; } }
    }
}