using Laby.Controller;
using Laby.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laby
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController gameController;
        public MainWindow()
        {
            InitializeComponent();

            LabyLogic labyLogic = new LabyLogic();
            display.SetupModel(labyLogic);

            //irányítás
            gameController = new GameController(labyLogic);
        
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        //irányításhoz a keydown esemény
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            gameController.KeyPressed(e.Key);
            display.InvalidateVisual();
        }
    }
}
