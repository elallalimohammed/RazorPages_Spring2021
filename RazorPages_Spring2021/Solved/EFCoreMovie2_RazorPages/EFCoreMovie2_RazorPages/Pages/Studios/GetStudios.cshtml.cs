﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie_RazorPages.Services.Interfaces;
using EFCoreMovie2_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreMovie2_RazorPages.Pages.Studios
{
    public class GetStudiosModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        private IStudioService studioService;
        public GetStudiosModel(IStudioService service)
        {
            studioService = service;
        }      
        public IEnumerable<Studio> Studios { get; set; } = new List<Studio>();
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Studios = studioService.GetStudios(FilterCriteria);
            }
            else
                Studios = studioService.GetStudios();
        }
    }
}