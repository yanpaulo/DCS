using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DesafioControlSmart.Data;
using DesafioControlSmart.WebApp.Data;

namespace DesafioControlSmart.WebApp.Pages.DeviceEvents
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
        public DeviceEvent DeviceEvent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeviceEvents.Add(DeviceEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}