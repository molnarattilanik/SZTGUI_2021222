using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MovieDbApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MovieDbApp.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Actor> Actors { get; set; }

        private Actor selectedActor;

        public Actor SelectedActor
        {
            get { return selectedActor; }
            set
            {
                if (value != null)
                {
                    selectedActor = new Actor()
                    {
                        ActorName = value.ActorName,
                        ActorId = value.ActorId
                    };
                    OnPropertyChanged();
                    (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateActorCommand { get; set; }

        public ICommand DeleteActorCommand { get; set; }

        public ICommand UpdateActorCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Actors = new RestCollection<Actor>("http://localhost:53910/", "actor", "hub");
                CreateActorCommand = new RelayCommand(() =>
                {
                    Actors.Add(new Actor()
                    {
                        ActorName = SelectedActor.ActorName
                    });
                });

                UpdateActorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Actors.Update(SelectedActor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                    
                });

                DeleteActorCommand = new RelayCommand(() =>
                {
                    Actors.Delete(SelectedActor.ActorId);
                },
                () =>
                {
                    return SelectedActor != null;
                });
                SelectedActor = new Actor();
            }
            
        }
    }
}
