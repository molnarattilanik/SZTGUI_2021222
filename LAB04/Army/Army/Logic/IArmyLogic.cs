using Army.Models;
using System.Collections.Generic;

namespace Army.Logic
{
    public interface IArmyLogic
    {
        int AllCost { get; }
        double AvgPower { get; }
        double AvgSpeed { get; }

        void AddArmy(Trooper trooper);
        void EditTrooper(Trooper trooper);
        void RemoveFromArmy(Trooper trooper);
        void SetUpCollections(IList<Trooper> barracks, IList<Trooper> army);
    }
}