namespace System.Reactive.Linq
{
    using System;

    public static partial class ObservableExSSSS
    {
        public static IObservable<T> FromValues<T>(params T[] values)
        {
            return values.ToObservable();
        }
    }
}