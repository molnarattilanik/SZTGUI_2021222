using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaOrderingWithDataBinding
{
    public class Order : INotifyPropertyChanged
    {

        private string personName;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        private string pizzaName;

        public string PizzaName
        {
            get { return pizzaName; }
            set { pizzaName = value; }
        }

        private string isTomato;

        public string IsTomato
        {
            get { return isTomato; }
            set { isTomato = value; OnPropertyChange(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}