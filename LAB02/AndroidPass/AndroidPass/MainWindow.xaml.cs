using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AndroidPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool selectionStarted;
        private readonly string code = "74123";
        private string inputCode = "";
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Source is Label source) && selectionStarted)
            {
                source.Background = Brushes.Green;
                if (!inputCode.Contains(source.Tag.ToString()))
                {
                    inputCode += source.Tag.ToString();
                }
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectionStarted = true;
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectionStarted = false;

            if (code.Equals(inputCode))
            {
                MessageBox.Show("Logged in successfully.");
            }

            foreach (var child in myGrid.Children)
            {
                if (child is Label)
                {
                    (child as Label).Background = Brushes.LightBlue;
                    inputCode = "";
                }
            }
        }
    }
}
