namespace FirstRxExample
{
    using System;
    using System.Collections.Generic;

    class StockMonitor : IDisposable
    {
        private readonly StockTicker _ticker;

        private readonly object _stockTickLocker = new object();
        private readonly Dictionary<string, StockInfo> _stockInfos = new Dictionary<string, StockInfo>();

        public StockMonitor(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.StockTick += OnStockTick;
        }

        void OnStockTick(object sender, StockTick stockTick)
        {
            const decimal maxChangeRatio = 0.1m;
            var quoteSymbol = stockTick.QuoteSymbol;
            lock (_stockTickLocker)
            {
                if (_stockInfos.TryGetValue(quoteSymbol, out StockInfo stockInfo))
                {
                    var priceDiff = stockTick.Price - stockInfo.PrevPrice;
                    var changeRatio = Math.Abs(priceDiff / stockInfo.PrevPrice); //#A the percentage of change
                    if (changeRatio > maxChangeRatio)
                    {
                        Console.WriteLine(
                            $"Stock:{quoteSymbol} has changed with {changeRatio} ratio, Old Price:{stockInfo.PrevPrice} New Price:{stockTick.Price}");
                    }
                    stockInfo.PrevPrice = stockTick.Price;
                }
                else
                {
                    _stockInfos[quoteSymbol] = new StockInfo(quoteSymbol, stockTick.Price);
                }
            }
        }

        public void Dispose()
        {
            _ticker.StockTick -= OnStockTick;
            _stockInfos.Clear();
        }
    }
}