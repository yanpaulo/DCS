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
    public class DeleteModel : PageModel
    {
        private readonly DesafioIControlSmart.WebApp.Data.ApplicationDbContext _context;

        public DeleteModel(DesafioIControlSmart.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Camera = await _context.Cameras.FindAsync(id);

            if (Camera != null)
            {
                _context.Cameras.Remove(Camera);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
