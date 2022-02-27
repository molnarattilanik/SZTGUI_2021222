using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace PizzaOrderingWithDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Order> orders;
        public MainWindow()
        {
            InitializeComponent();
            orders = new ObservableCollection<Order>();

            if (File.Exists("orders.json"))
            {
                var orderArray = JsonConvert.DeserializeObject<Order[]>(File.ReadAllText("orders.json"));
                orderArray.ToList().ForEach(o => orders.Add(o));
            }

            pizzaName.Items.Add("Mexikói");
            pizzaName.Items.Add("Magyaros");
            pizzaName.Items.Add("Húsimádó");
            pizzaName.Items.Add("Hawaai");
            pizzaName.Items.Add("Vega");

            orders_listBox.ItemsSource = orders;
        }

        private void order_btn_Click(object sender, RoutedEventArgs e)
        {
            orders.Add(new Order());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var ordersInJson = JsonConvert.SerializeObject(orders);
            File.WriteAllText("orders.json", ordersInJson);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (orders_listBox.SelectedItem is Order order)
            {
                if (order.IsTomato == "paradicsomos")
                {
                    order.IsTomato = "tejfölös";
                }
                else
                {
                    order.IsTomato = "paradicsomos";
                }
            }
        }
    }
}
