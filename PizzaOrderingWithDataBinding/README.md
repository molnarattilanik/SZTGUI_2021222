# Lab01 Pizzás feladata kiegészítése adatkötéssel

Extra feladat, hogy a pizza rendelést kiegészítsük adatkötéssel. 
Változások:
- Új rendelés felvételnél egy üres rendelés jön létre.
- ListBox egy elemére kattintva válik szerkeszthetővé az adott rendelés
- Radio button-t írjuk át checkbox-ra
- Extra gomb: pizza alap változtatása ami paradicsomosról tejfölös alapra vált illetve vissza


![Screenshot](PizzaOrderWithBinding.png)

---

# Kulcs pontok

Problémák az adatkötésnél

1. ToSrting() elkerülése ItemTemplate használatával

```xml
<ListBox x:Name="orders_listBox" Grid.Column="1">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <Label Content="{Binding PersonName}" ContentStringFormat="Név: {0}"/>
                        <Label Content="{Binding PizzaName}" ContentStringFormat="Pizzafajtája: {0}"/>
                        <Label Content="{Binding IsTomato}" ContentStringFormat="Alap: {0}"/>
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
```

Vegyük észre a ContentStringFormat használatát.


2. Alap váltás gombra kattintva változik, hogy az adott feltét paradicsomos vagy tejfölös. Ekkor a UI nincs értesítve megfelelően a tulajdonság megváltozásáról. Megoldás: INotifyPropertyChanged interfész implementálása 

```c#
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

```


3. Új rendelés felvétel esetén a belső lista nem frissül, ha csak egy sima beépített ``List`` gyűjteményt használunk. Helyette használjuk a következőt: 
```c#
using System.Collections.ObjectModel;

ObservableCollection<Order> orders;
```


4. A paradicsomos értéknél egy bool érték jön fel, viszont szeretnék, hogy igaz esetén a 'paradicsomos' hamis eseté a 'tejfölös' szöveg jelenjen meg. Ehhez szükségünk van egy Converter osztályra és az '''IValueConverter''' interfész megvalósítására. IsTomato átírása string-é!!

```c#

using System;
using System.Globalization;
using System.Windows.Data;

namespace PizzaOrderingWithDataBinding
{
    public class PizzaBaseToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == "paradicsomos" ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "paradicsomos" : "tejfölös";
        }
    }
}

```


Convert esetben a forrástól a cél felé convertálunk. 
ConvertBack esetén a céltól a forrás felé convertálunk.


Xaml-ben a felhasználása mint erőforrás:

```xml
   <Window.Resources>
        <local:PizzaBaseToBoolConverter x:Key="pizzaBaseConverter" />
    </Window.Resources>


    <CheckBox Content="Paradicsomos" IsChecked="{Binding IsTomato, Converter={StaticResource pizzaBaseConverter}}" Margin="10"/>

```


