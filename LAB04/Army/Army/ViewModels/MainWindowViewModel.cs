using Army.Logic;
using Army.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Army.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
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
        private readonly IArmyLogic armyLogic;

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
                return armyLogic.AllCost;
            }
        }

        public double AvgPower
        {
            get
            {
                return armyLogic.AvgPower;
            }
        }
        public double AvgSpeed
        {
            get
            {
                return armyLogic.AvgSpeed;
            }
        }

        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {
        }

        public MainWindowViewModel(IArmyLogic armyLogic)
        {
            this.armyLogic = armyLogic;

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

            armyLogic.SetUpCollections(Barrack, Army);

            AddToArmyCommand = new RelayCommand(
                () => armyLogic.AddArmy(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => armyLogic.RemoveFromArmy(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            EditTrooperCommand = new RelayCommand(
                () => armyLogic.EditTrooper(SelectedFromBarrack),
                () => selectedFromBarrack != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recepient, msg) =>
            {
                //jön üzi akkor frissüljön a UI-hoz bekötött property
                OnPropertyChanged(nameof(AllCost));
                OnPropertyChanged(nameof(AvgPower));
                OnPropertyChanged(nameof(AvgSpeed));
            });
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
