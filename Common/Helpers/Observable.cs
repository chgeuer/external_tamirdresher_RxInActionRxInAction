namespace System.Reactive.Linq
{
    using System;
    using System.Reactive.Linq;

    public static partial class ObservableExSSSS
    {
        public static IObservable<T> FromValues<T>(params T[] values)
        {
            return values.ToObservable();
        }
    }
}