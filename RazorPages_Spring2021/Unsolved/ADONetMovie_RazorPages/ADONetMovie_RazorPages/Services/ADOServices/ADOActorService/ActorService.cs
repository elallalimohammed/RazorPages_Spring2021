
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOActorService
{
    public class ActorService : IActorService
    {
        private AdonetActorService actorService;
        public ActorService(AdonetActorService service)
        {
            actorService = service;
        }
         public IEnumerable<Actor> GetActors()
        {
            return actorService.GetAllActors();
        }
    }
}
