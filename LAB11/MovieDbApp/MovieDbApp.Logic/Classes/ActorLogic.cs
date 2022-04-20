using MovieDbApp.Models;
using MovieDbApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.Logic
{
    public class ActorLogic : IActorLogic
    {
        IRepository<Actor> repo;

        public ActorLogic(IRepository<Actor> repo)
        {
            this.repo = repo;
        }

        public void Create(Actor item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Actor Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Actor> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Actor item)
        {
            this.repo.Update(item);
        }
    }
}
