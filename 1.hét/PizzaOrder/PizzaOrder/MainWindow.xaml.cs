using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PizzaOrder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("orders.json"))
            {
                var pizzas = JsonConvert.DeserializeObject<Order[]>(File.ReadAllText("orders.json"));
                pizzas.ToList().ForEach(o => orders_listBox.Items.Add(o));
            }

            pizzaName_comboBox.Items.Add("Mexikói");
            pizzaName_comboBox.Items.Add("Magyaros");
            pizzaName_comboBox.Items.Add("Vega");
            pizzaName_comboBox.Items.Add("Húsimádó");

            pizzaName_comboBox.SelectedIndex = 0;
        }

        private void order_button_Click(object sender, RoutedEventArgs e)
        {
            Order pizzaOrder = new Order(personName_textBox.Text, pizzaName_comboBox.SelectedItem.ToString(), tomato_radioButton.IsChecked);
            orders_listBox.Items.Add(pizzaOrder);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var orders = new List<Order>();
            foreach (var item in orders_listBox.Items)
            {
                orders.Add(item as Order);
            }

            var ordersInJson = JsonConvert.SerializeObject(orders);

            File.WriteAllText("orders.json", ordersInJson);
        }
    }
}
