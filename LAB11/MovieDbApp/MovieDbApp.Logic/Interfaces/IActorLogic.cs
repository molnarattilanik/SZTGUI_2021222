using MovieDbApp.Models;
using System.Linq;

namespace MovieDbApp.Logic
{
    public interface IActorLogic
    {
        void Create(Actor item);
        void Delete(int id);
        Actor Read(int id);
        IQueryable<Actor> ReadAll();
        void Update(Actor item);
    }
}