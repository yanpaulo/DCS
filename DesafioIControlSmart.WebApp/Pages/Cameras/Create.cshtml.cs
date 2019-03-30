using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DesafioIControlSmart.Data;
using DesafioIControlSmart.WebApp.Data;

namespace DesafioIControlSmart.WebApp.Pages.Cameras
{
    public class CreateModel : PageModel
    {
        private readonly DesafioIControlSmart.WebApp.Data.ApplicationDbContext _context;

        public CreateModel(DesafioIControlSmart.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Camera Camera { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cameras.Add(Camera);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}