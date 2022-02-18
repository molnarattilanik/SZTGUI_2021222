using System.Windows;

namespace EnglishWords
{
    /// <summary>
    /// Interaction logic for WordCheckWindow.xaml
    /// </summary>
    public partial class WordCheckWindow : Window
    {
        private readonly Word word;

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
