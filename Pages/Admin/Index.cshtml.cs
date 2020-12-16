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
    public class IndexModel : PageModel
    {
        private readonly SourceCode.Data.SourceCodeContext _context;

        public IndexModel(SourceCode.Data.SourceCodeContext context)
        {
            _context = context;
        }

        public IList<Party> Party { get;set; }

        public async Task OnGetAsync()
        {
            Party = await _context.partyList.ToListAsync();
        }
    }
}
