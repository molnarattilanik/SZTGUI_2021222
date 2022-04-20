using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MovieDbApp.Endpoint.Services;
using MovieDbApp.Logic;
using MovieDbApp.Models;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorLogic logic;
        IHubContext<SignalRHub> hub;

        public ActorController(IActorLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Actor> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Actor Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Actor value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ActorCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Actor value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ActorUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ActorDeleted", actorToDelete);
        }
    }
}
