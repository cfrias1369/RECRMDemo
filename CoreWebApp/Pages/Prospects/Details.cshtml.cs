using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreWebApp.Models;

namespace CoreWebApp.Pages.Prospects
{
    public class DetailsModel : PageModel
    {
        private readonly CoreWebApp.Models.RECRMDBContext _context;

        public DetailsModel(CoreWebApp.Models.RECRMDBContext context)
        {
            _context = context;
        }

        public Prospect Prospect { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prospect = await _context.Prospects.FirstOrDefaultAsync(m => m.Id == id);

            if (Prospect == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
