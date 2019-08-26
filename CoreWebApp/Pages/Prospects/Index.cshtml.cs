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
    public class IndexModel : PageModel
    {
        private readonly CoreWebApp.Models.RECRMDBContext _context;

        public IndexModel(CoreWebApp.Models.RECRMDBContext context)
        {
            _context = context;
        }

        public IList<Prospect> Prospect { get;set; }

        public async Task OnGetAsync()
        {
            Prospect = await _context.Prospects.ToListAsync();
        }
    }
}
