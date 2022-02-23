using System.Collections.ObjectModel;
using System.Windows;

namespace MiniEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Person> people;
        public MainWindow()
        {
            InitializeComponent();
            people = new ObservableCollection<Person>
            {
                new Person() {Name = "Kati", Age = 20, HaveGlasses = "igen"},
                new Person() {Name = "Jószi", Age = 30, HaveGlasses = "nem"},
                new Person() {Name = "Nóra", Age = 40, HaveGlasses = "igen"},
            };

            listBox.ItemsSource = people;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem is Person person)
            {
                if (person.HaveGlasses == "igen")
                {
                    person.HaveGlasses = "nem";
                }
                else
                {
                    person.HaveGlasses = "igen";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            people.Add(new Person());
        }
    }
}
