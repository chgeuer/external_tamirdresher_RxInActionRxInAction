namespace ObservablesFromEvents
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Windows;
    using Helpers;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IObservable<EventPattern<RoutedEventArgs>> clicks =
                Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
                    h => theButton.Click += h,
                    h => theButton.Click -= h);

            //IObservable<EventPattern<object>> clicks = Observable.FromEventPattern(theButton, "Click");

            // the message will be written to VS output window
            clicks.SubscribeConsole();

            clicks.Subscribe(eventPattern =>
            {
                var msg = "button clicked" + Environment.NewLine;
                output.Text += msg;
            });
        }
    }
}