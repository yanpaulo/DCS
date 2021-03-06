﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DesafioControlSmart.Data;
using DesafioControlSmart.WebApp.Data;

namespace DesafioControlSmart.WebApp.Pages.Gates
{
    public class DetailsModel : PageModel
    {
        private readonly DesafioControlSmart.WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(DesafioControlSmart.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Gate Gate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gate = await _context.Gates.FirstOrDefaultAsync(m => m.Id == id);

            if (Gate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
