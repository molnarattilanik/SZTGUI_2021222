using Army.Models;
using Army.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Army
{
    /// <summary>
    /// Interaction logic for TrooperEditorWindow.xaml
    /// </summary>
    public partial class TrooperEditorWindow : Window
    {
        public TrooperEditorWindow(Trooper trooper)
        {
            InitializeComponent();
            this.DataContext = new TrooperEditorWindowViewModel();
            (this.DataContext as TrooperEditorWindowViewModel).SetUp(trooper);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox textBox)
                {
                    //most történjen meg az adatkötés
                    textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
