using Army.Models;
using Army.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> barracks;
        IList<Trooper> army;
        private readonly IMessenger messenger;
        private readonly ITrooperEditorService trooperEditorService;

        public int AllCost
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(a => a.Cost);
            }
        }

        public double AvgPower
        {
            get
            {
                return army.Count == 0 ? 0 : army.Average(a => a.Power);
            }
        }
        public double AvgSpeed
        {
            get
            {
                return army.Count == 0 ? 0 : army.Average(a => a.Speed);
            }
        }

        public ArmyLogic(IMessenger messenger, ITrooperEditorService trooperEditorService)
        {
            this.messenger = messenger;
            this.trooperEditorService = trooperEditorService;
        }

        public void SetUpCollections(IList<Trooper> barracks, IList<Trooper> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddArmy(Trooper trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper Added", "TrooperInfo");
        }

        public void RemoveFromArmy(Trooper trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper Removed", "TrooperInfo");
        }

        public void EditTrooper(Trooper trooper)
        {
            //army.Add(trooper.GetCopy());
            trooperEditorService.Edit(trooper);
        }
    }
}
