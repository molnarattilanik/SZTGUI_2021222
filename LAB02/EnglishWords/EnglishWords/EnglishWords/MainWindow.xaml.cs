using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishWords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var words = File.ReadAllLines("words.txt").Select(w => new Word(w.Split(':')[1], w.Split(':')[0])).ToList();

            words.ForEach(word =>
            {
                Label label = new Label();
                label.Tag = word;
                label.Background = Brushes.LightBlue;
                label.Margin = new Thickness(20);
                label.Width = this.ActualWidth / 6;
                label.Height = this.ActualHeight / 6;
                wrapPanel.Children.Add(label);

                label.MouseLeftButtonDown += Label_MouseLeftButtonDown;
            });
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label label)
            {
                var word = (Word)label.Tag;
                var wordCheckWindow = new WordCheckWindow(word);

                if (wordCheckWindow.ShowDialog() == true)
                {
                    label.Background = Brushes.LightGreen;
                    label.IsEnabled = false;
                }
                else
                {
                    label.Background = Brushes.LightPink;
                }
            }
        }
    }
}
