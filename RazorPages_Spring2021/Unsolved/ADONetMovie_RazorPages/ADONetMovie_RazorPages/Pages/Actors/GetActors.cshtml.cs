using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages
{
    public class GetActorsModel : PageModel
    {
         public IEnumerable<Actor> Actors{ get; set; }

        IActorService actorService { get; set; }
        public GetActorsModel(IActorService service)
        {
            actorService = service;
        }
        public void OnGet()
        {         
            Actors = actorService.GetActors();
        }
    }
}