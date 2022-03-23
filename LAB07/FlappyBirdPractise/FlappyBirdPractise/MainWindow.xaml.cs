using FlappyBird.Logic;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FlappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlappyLogic flappyLogic;
        DispatcherTimer dispatcherTimer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            flappyLogic = new FlappyLogic(grid.ActualWidth, grid.ActualHeight);
            display.SetupDisplay(flappyLogic);

            flappyLogic.GameOver += FlappyLogic_GameOver;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Tick += (sender, eventargs) =>
            {
                flappyLogic.TimeStep(grid.ActualWidth, grid.ActualHeight);
                display.InvalidateVisual();
            };
            dispatcherTimer.Start();
        }

        private void FlappyLogic_GameOver(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            MessageBox.Show("Gém óver!");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                flappyLogic.Bird.Jump();
        }
    }
}
