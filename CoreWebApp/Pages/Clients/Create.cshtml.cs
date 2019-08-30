using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreWebApp.Models;

namespace CoreWebApp.Pages.Clients
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
            Client = new Client();

            Client.FirstName = Request.Query["FirstName"].ToString();
            Client.PhoneNumber1 = Request.Query["PhoneNumber1"].ToString();
            Client.InitialContactDate = Request.Query["InitialContactDate"].ToString();
            Client.InitialContactNotes = Request.Query["InitialContactNotes"].ToString();

            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}