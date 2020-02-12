namespace AsyncObservables.SearchEngine
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class SearchEngineA : ISearchEngine
    {
        public async Task<IEnumerable<string>> SearchAsync(string term)
        {
            await Console.Out.WriteLineAsync("SearchEngine A - SearchAsync()");
            await Task.Delay(1500);//simulate latency
            return new[] { "resultA", "resultB" };
        }
    }
}