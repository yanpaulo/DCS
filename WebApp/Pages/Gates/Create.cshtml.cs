using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DesafioControlSmart.Data;
using DesafioControlSmart.WebApp.Data;

namespace DesafioControlSmart.WebApp.Pages.Gates
{
    public class CreateModel : PageModel
    {
        private readonly DesafioControlSmart.WebApp.Data.ApplicationDbContext _context;

        public CreateModel(DesafioControlSmart.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Gate Gate { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Gates.Add(Gate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}