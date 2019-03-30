using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DesafioIControlSmart.Data;
using DesafioIControlSmart.WebApp.Data;

namespace DesafioIControlSmart.WebApp.Pages.Cameras
{
    public class DetailsModel : PageModel
    {
        private readonly DesafioIControlSmart.WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(DesafioIControlSmart.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Camera Camera { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Camera = await _context.Cameras.FirstOrDefaultAsync(m => m.Id == id);

            if (Camera == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
