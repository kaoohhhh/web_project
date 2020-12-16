using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SourceCode.Data;
using SourceCode.Models;

namespace SourceCode.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly SourceCode.Data.SourceCodeContext _context;

        public CreateModel(SourceCode.Data.SourceCodeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Party Party { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.partyList.Add(Party);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}