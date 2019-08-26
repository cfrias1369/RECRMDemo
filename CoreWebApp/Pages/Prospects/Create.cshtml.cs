using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreWebApp.Models;

namespace CoreWebApp.Pages.Prospects
{
    public class CreateModel : PageModel
    {
        private readonly CoreWebApp.Models.RECRMDBContext _context;

        public CreateModel(CoreWebApp.Models.RECRMDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Prospect Prospect { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prospect.Add(Prospect);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}