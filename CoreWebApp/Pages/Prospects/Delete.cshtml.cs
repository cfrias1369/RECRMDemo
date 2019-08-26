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
    public class DeleteModel : PageModel
    {
        private readonly CoreWebApp.Models.RECRMDBContext _context;

        public DeleteModel(CoreWebApp.Models.RECRMDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prospect Prospect { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prospect = await _context.Prospect.FirstOrDefaultAsync(m => m.Id == id);

            if (Prospect == null)
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

            Prospect = await _context.Prospect.FindAsync(id);

            if (Prospect != null)
            {
                _context.Prospect.Remove(Prospect);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
