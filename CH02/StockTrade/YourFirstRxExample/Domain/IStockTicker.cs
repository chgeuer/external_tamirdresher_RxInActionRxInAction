namespace FirstRxExample
{
    using System;

    public interface IStockTicker
    {
        event EventHandler<StockTick> StockTick;
    }
}