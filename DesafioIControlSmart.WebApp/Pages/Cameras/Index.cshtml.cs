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
    public class IndexModel : PageModel
    {
        private readonly DesafioIControlSmart.WebApp.Data.ApplicationDbContext _context;

        public IndexModel(DesafioIControlSmart.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Camera> Camera { get;set; }

        public async Task OnGetAsync()
        {
            Camera = await _context.Cameras.ToListAsync();
        }
    }
}
