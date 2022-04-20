using MovieDbApp.Models;
using System.Linq;

namespace MovieDbApp.Logic
{
    public interface IDirectorLogic
    {
        void Create(Director item);
        void Delete(int id);
        Director Read(int id);
        IQueryable<Director> ReadAll();
        void Update(Director item);
    }
}