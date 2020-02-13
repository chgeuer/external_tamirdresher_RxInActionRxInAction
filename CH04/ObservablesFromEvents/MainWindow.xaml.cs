using Helpers;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace ObservablesFromEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

            // the message will be written in the TextBox
            clicks.Subscribe(eventPattern => output.Text += "button clicked" + Environment.NewLine);
        }
    }
}
