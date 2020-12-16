using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SourceCode.Data;
using SourceCode.Models;

namespace SourceCode.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly SourceCode.Data.SourceCodeContext _context;

        public DetailsModel(SourceCode.Data.SourceCodeContext context)
        {
            _context = context;
        }

        public Party Party { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Party = await _context.partyList.FirstOrDefaultAsync(m => m.ID == id);

            if (Party == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
