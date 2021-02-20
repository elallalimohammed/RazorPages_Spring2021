﻿using EFCoreMovie2_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie_RazorPages.Services.Interfaces
{
    public interface IStudioService
    {
        IEnumerable<Studio> GetStudios(string filter);
        IEnumerable<Studio> GetStudios();
    }
}
