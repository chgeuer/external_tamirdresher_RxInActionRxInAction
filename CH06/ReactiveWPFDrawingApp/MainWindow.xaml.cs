using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ReactiveWPFDrawingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDisposable _subscription;

        public MainWindow()
        {
            InitializeComponent();



            var mouseDowns = Observable.FromEventPattern<MouseButtonEventArgs>(this, "MouseDown");
            var mouseUp = Observable.FromEventPattern<MouseButtonEventArgs>(this, "MouseUp");
            var movements = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove");




            Polyline line = null;
            _subscription =
                 movements
                 .SkipUntil(
                     mouseDowns.Do(_ =>
                     {
                         line = new Polyline() { Stroke = Brushes.Black, StrokeThickness = 3 };
                         canvas.Children.Add(line);
                     }))
                 .TakeUntil(mouseUp)
                 .Select(m => m.EventArgs.GetPosition(this))
                 .Repeat()
                 .Subscribe(pos => line.Points.Add(pos));




        }
    }
}
