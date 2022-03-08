using Army.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Army.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public ObservableCollection<Trooper> Barrack { get; set; }
        public ObservableCollection<Trooper> Army { get; set; }

        private Trooper selectedFromBarrack;

        public Trooper SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set 
            {
                SetProperty(ref selectedFromBarrack, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Trooper selectedFromArmy;

        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set 
            {
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand EditTrooperCommand { get; set; }

        public int AllCost
        {
            get
            {
                return 987;
            }
        }

        public double AvgPower
        {
            get
            {
                return 9;
            }
        }
        public int AvgSpeed
        {
            get
            {
                return 7;
            }
        }

        public MainViewModel()
        {
            Barrack = new ObservableCollection<Trooper>();
            Army = new ObservableCollection<Trooper>();

            Barrack.Add(new Trooper()
            {
                Type = "marine",
                Power = 10,
                Speed = 5,
            });
            Barrack.Add(new Trooper()
            {
                Type = "pilot",
                Power = 11,
                Speed = 2,
            });
            Barrack.Add(new Trooper()
            {
                Type = "sniper",
                Power = 5,
                Speed = 5,
            });
            Barrack.Add(new Trooper()
            {
                Type = "tank",
                Power = 6,
                Speed = 1,
            });
            Barrack.Add(new Trooper()
            {
                Type = "dron",
                Power = 6,
                Speed = 1,
            });

            Army.Add(Barrack[2].GetCopy());
            Army.Add(Barrack[4].GetCopy());


            AddToArmyCommand = new RelayCommand(
                () => Army.Add(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => Army.Remove(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            EditTrooperCommand = new RelayCommand(
                () => Army.Add(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );
        }
    }
}
