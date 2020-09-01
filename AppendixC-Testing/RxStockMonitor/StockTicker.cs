namespace RxStockMonitor
{
    using System;

    public class DrasticChange
    {
        public decimal NewPrice { get; set; }
        public string Symbol { get; set; }
        public decimal ChangeRatio { get; set; }
        public decimal OldPrice { get; set; }
    }

    public interface IStockTicker
    {
        event EventHandler<StockTick> StockTick;
    }

    public class StockTicker : IStockTicker
    {
        public event EventHandler<StockTick> StockTick = delegate { };

        public void Notify(StockTick tick)
        {
            StockTick(this, tick);
        }
    }

    public class StockTick
    {
        public string QuoteSymbol { get; set; }
        public decimal Price { get; set; }
    }

    internal class StockInfo
    {
        public string Symbol { get; set; }
        public decimal PrevPrice { get; set; }

        public StockInfo(string symbol, decimal price)
        {
            Symbol = symbol;
            PrevPrice = price;
        }
    }
}