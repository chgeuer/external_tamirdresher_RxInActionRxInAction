using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;

namespace SearchScreenWithDistinctUntilChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Observable.FromEventPattern(SearchTerm, "TextChanged")
                .Select(_ => SearchTerm.Text)
                .Throttle(TimeSpan.FromMilliseconds(400))
                .DistinctUntilChanged()
                .ObserveOnDispatcher()
                .Subscribe(s => Terms.Items.Add(s));
        }
    }
}
