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
using System.Windows.Shapes;

namespace EnglishWords
{
    /// <summary>
    /// Interaction logic for WordCheckWindow.xaml
    /// </summary>
    public partial class WordCheckWindow : Window
    {
        private Word word;
        public WordCheckWindow(Word word)
        {
            InitializeComponent();
            this.word = word;
            hun_label.Content = word.Hungarian;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (eng_textBox.Text == word.English)
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
