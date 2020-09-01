namespace CreatingObservables.ContinousSearch
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Timers;

    internal static class Searcher
    {
        public static IObservable<string> Create(string term)
        {
            return Observable.Create<string>(observer =>
            {
                var timer = new Timer(2000);
                timer.Elapsed += (sender, args) =>
                {
                    var results = SearchEngine.Search(term);
                    foreach (var result in results)
                    {
                        observer.OnNext(result);
                    }
                };

                return () =>
                {
                    //timer.d
                };
            });
        }
    }

    internal class SearchEngine
    {
        public static IEnumerable<string> Search(string term)
        {
            yield return term + "1";
            yield return term + "2";
            yield return term + "3";
        }
    }
}
